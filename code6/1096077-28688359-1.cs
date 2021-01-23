    public class Class_many
        {
            public int ID { get; set; }
            public string Name { get; set; }
    
            private ICollection<Class_several> _severals;
    
            public virtual Class_oneOnly Class_oneOnly { get; set; }
            public virtual ICollection<Class_several> Class_severals { get
            {
                if (_severals == null) {_severals = new List<Class_several>();}
                return _severals;
            }
                set { _severals = value; }
            }
        }
