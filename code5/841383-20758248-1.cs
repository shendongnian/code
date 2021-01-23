    public static class TypeSwitcher
    {
        public static dynamic inCase<T>(this object item,Func<dynamic> function)
        {
            if (item.GetType() == typeof(T))
                return function();
            else
                return "";
        }
    }
    static void Main(string[] args)
        {
            List<object> bobbies = new List<object>();
            bobbies.Add(new Hashtable());
            bobbies.Add(string.Empty);
            bobbies.Add(new List<string>());
            bobbies.Add(108);
            bobbies.Add(10);
            bobbies.Add(typeof(string));
            bobbies.Add(typeof(string));
            foreach (var item in bobbies)
            {
               Console.WriteLine(item.inCase<Hashtable>(() => "one"));
               Console.WriteLine(item.inCase<String>(() => "two"));
               Console.WriteLine(item.inCase<int>(() => "three"));
               
            }
            Console.ReadLine();
        }
