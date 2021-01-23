    class Table1
    {
        public int Id1 { get; set; }
        public string Column1 { get; set; }
    }
    class Table2
    {
        public int Id2 { get; set; }
        public string Column2 { get; set; }
    }
    class Table3
    {
        public int Id3 { get; set; }
        public string Column3 { get; set; }
    }
        static void Main(string[] args)
        {
            var table1 = new List<Table1>();
            var table2 = new List<Table2>();
            var table3 = new List<Table3>();
            for (int i = 0; i < 10; i++)
            {
                table1.Add(new Table1 { Id1 = i, Column1 = "column1_table1_" + i });
                table2.Add(new Table2 { Id2 = i, Column2 = "column2_table2_" + i });
                table3.Add(new Table3 { Id3 = i, Column3 = "column3_table3_" + i });
            }
            var table1JoinTable2 = table1.Join(table2, t1 => t1.Id1, t2 => t2.Id2, (t1, t2) => new { Id = t1.Id1, Column1 = t1.Column1, Column2 = t2.Column2 } );
            var table1JoinTable2JoinTable3 = table1JoinTable2.Join(table3, t12 => t12.Id, t3 => t3.Id3, (t12, t3) => new { Id = t12.Id, Column1 = t12.Column1, Column2 = t12.Column2, Column3 = t3.Column3 });
            var result1 = table1JoinTable2JoinTable3.Single(t123 => t123.Id == 1);
            Console.WriteLine("Id={0} C1={1} C2={2} C3={3}", result1.Id, result1.Column1, result1.Column2, result1.Column3);
            // prints "Id=1 C1=column_table1_1 C2=column_table2_1 C3=column_table3_1"
        }
