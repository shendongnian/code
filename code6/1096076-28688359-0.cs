    public class Class_many
        {
            public int ID { get; set; }
            public string Name { get; set; }
    
            private ICollection<Class_several> _severals;
    
            public virtual Class_oneOnly Class_oneOnly { get; set; }
            public virtual ICollection<Class_several> Class_severals { get
            {
                return _severals ?? new List<Class_several>();
            }
                set { _severals = value; }
            }
        }
