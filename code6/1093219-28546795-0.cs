    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("foo",typeof(string));
            table.Columns.Add("bar",typeof(int));
            table.Rows.Add("row1", 1);
            table.Rows.Add("row2", 2);
            var result = table.MapTableToList<foobar>();
            foreach (foobar item in result)
            {
                Console.WriteLine("{0}:{1}", item.foo, item.bar);
            }
        }
    }
    class foobar
    {
        public string foo { get; set; }
        public int bar { get; set; }
    }
    public static class ExtensionMethods
    { 
        public static List<T> MapTableToList<T>(this DataTable table) where T : new ()
        {
            List<T> result = new List<T>();
            var Type = typeof(T);
            foreach (DataRow row in table.Rows)
            {
                T item = new T();
                foreach (var property in Type.GetProperties())
                {
                    property.SetMethod.Invoke(item, new object[] { row[table.Columns[property.Name]] });
                }
                result.Add(item);
            }
            return result;
        }
    }
