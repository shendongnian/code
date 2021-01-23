    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            Load(new Repository<int>());
            Load(new Repository<string>());
            Console.ReadLine();
        }
        class Repository<T> { }
        static List<T> Load<T>(Repository<T> repository)
        {
            Console.WriteLine("Debug: List<{1}> Load<{1}>({0}<{1}> repository)", typeof(Repository<T>).Name, typeof(Repository<T>).GenericTypeArguments.First());
            return default(List<T>);
        }
    }
