    public class MyClass
        {
            private readonly string _Navn;
            public MyClass(string name, Int id)
            {
                Id = id;
                Name = name;
            }
            public int Id{ get; }
            public override string ToString()
            {
                return Name;
            }
        }
