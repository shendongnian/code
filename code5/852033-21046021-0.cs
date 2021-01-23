    public class Obj
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class ListObj : List<Obj>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Rows.Add("1", "AAA");
            dt.Rows.Add("2", "BBB");
            dt.Rows.Add("3", "CCC");
            ListObj objListObj = new ListObj();
            //to fill the list / collection
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objListObj.Add(new Obj() { ID = Convert.ToInt16(dt.Rows[i][0]), Name = dt.Rows[i][1].ToString() });
            }
            //To verify if the collection is filled.
            foreach (var item in objListObj)
            {
                Console.WriteLine(item.ID + " : " + item.Name);
            }
            Console.Read();
        }
    }
