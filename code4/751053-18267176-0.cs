        public class Status
        {
            public StatusEnum StatusEnum { get; set; }
            public string DisplayAs { get; set; }
            private readonly ICollection<int> functions = new List<int>;
            public ICollection<int> Functions { get { return functions; } }
        }
