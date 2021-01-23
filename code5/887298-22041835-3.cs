    class Program
    {
        static void Main(string[] args)
        {
            var obj = new ChildChildClass();
            var ChildChildType = obj.GetType();
            
            var p = new Program();
            // here we get the ChildClass properties
            var t = p.getBaseType(ChildChildType, 1);
            Console.WriteLine(t.Name);
            p.getproperties(t);
            // here we get the BaseClass properties
            t = p.getBaseType(ChildChildType, 2);
            Console.WriteLine(t.Name);
            p.getproperties(t);
            // here we get the Object properties
            t = p.getBaseType(ChildChildType, 3);
            Console.WriteLine(t.Name);
            p.getproperties(t);
            Console.Read();
        }
        internal Type getBaseType(Type t, int level)
        {
            Type temp ;
            for (int i = 0; i < level; i++)
            {
                temp = t.BaseType;
                if(temp == null)
                    throw new ArgumentOutOfRangeException("you are digging to deep");
                else
                    t = temp;
            }
            return t;
        }
        private void getproperties(Type t)
        {
            PropertyInfo[] properties = t.GetProperties(BindingFlags.DeclaredOnly |
                                                        BindingFlags.Public |
                                                        BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }
            Console.WriteLine("");
        }
    }
