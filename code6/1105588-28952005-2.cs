        public class TableA
        {
            public int Id { get; set; }
            public virtual List<TableB> TableBs { get; set; }
        }
        public class TableB
        {
            public int Id { get; set; }
            public virtual List<TableA> TableAs { get; set; }
        }
