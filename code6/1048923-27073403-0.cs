     static void Main(string[] args)
            {
                ClassA a = new ClassA();
                IterateInterfaceProperties(a.GetType());
                Console.ReadLine();
            }
        private static void IterateInterfaceProperties(Type type)
        {
            foreach (var face in type.GetInterfaces())
            {
                foreach (PropertyInfo prop in face.GetProperties())
                {
                    Console.WriteLine("{0}:: {1} [{2}]", face.Name, prop.Name, prop.PropertyType);
                }
            }
        }
