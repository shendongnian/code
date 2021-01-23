    class Program
    {
        static void Main(string[] args)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("ABC", typeof(string));
            var a = new CustomStruct() { IntValue = 1, DataTable = dataTable };
            Console.WriteLine("IsValueType: {0}", a.GetType().IsValueType);
            Console.WriteLine();
            var b = a;
            a.IntValue = 2;
            a.DataTable.Columns.Add("DEF", typeof(int));
            Console.WriteLine("a.IntValue: {0}", a.IntValue);
            Console.WriteLine("a.DataTable.Columns.Count: {0}", a.DataTable.Columns.Count);
            Console.WriteLine();
            Console.WriteLine("b.IntValue: {0}", b.IntValue);
            Console.WriteLine("b.DataTable.Columns.Count: {0}", b.DataTable.Columns.Count);
        }
    }
    public struct CustomStruct
    {
        public int IntValue;
        public DataTable DataTable;
    }
