        static void Main(string[] args)
        {
            var result1 = typeof (ClassLibrary2.Class1);
            var result2 = Type.GetType("ClassLibrary2.Class1");//returns null because Class1 is not in the currently executing assembly or mscorlib
            var assembly = Assembly.GetAssembly(typeof(ClassLibrary2.Class1));
            var result3 = Type.GetType("ClassLibrary2.Class1, " + assembly.FullName);
            Console.WriteLine("{0}, {1}, {2}", result1, result2, result3);
        }
