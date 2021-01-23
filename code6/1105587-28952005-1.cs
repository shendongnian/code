        public class DbContext
        {
            public IDbSet<TableA> TableAs { get; set; }
            public IDbSet<TableB> TableBs { get; set; }
        }
