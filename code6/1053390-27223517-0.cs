    public class Column
    {
        public string Name { get; set; }
        public int StartPos { get; set; }
        public int Length { get; set; }
    }
    public class Test
    {
        private List<Column> Columns = new List<Column>();
        public Test()
        {
            this.Columns.Add(new Column { Name = "FirstName", StartPos = 1, Length = 32 });
            this.Columns.Add(new Column { Name = "LastName", StartPos = 33, Length = 32 });
        }
        
        public string GetThatString(string chain)
        {
            foreach (var col in this.Columns)
            {
                // Do what you need.
                var item = chain.Substring(col.StartPos, col.Length);
                Console.WriteLine("{0}: {1}", col.Name, item);
            }
        }
    }
