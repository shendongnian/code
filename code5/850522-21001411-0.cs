    public class Student : People
        {
            private int id;
    
            public new String Name { get; set;}
    
            public Student()
            {
            }
    
            public Student(int id, string name)
            {
                this.id = id;
                this.Name = name;
            }
    
    
    
            public int ID
            {
                get
                {
                    return this.id;
                }
    
                set
                {
                    this.id = value;
                }
    
            }
        }
