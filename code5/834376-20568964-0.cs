        public abstract partial class MyClass
        {
            private static readonly List Types;
            static MyClass()
            {
                Types = new List<MyClass>();
                Types.Add(new Myclass(0));
                Types.Add(new Myclass(1));
            }
            public static MyClass GetMyClass(int id)
            {
                return Types.Single(x => x.id == id);
            }
        }
