     public class MyObject
        {
            public long Id { get; set; }
            public string Name { get; set; }
    
            public string ToString()
            {
                return string.Format("{0} {1}", Id, Name);
            }
        }
