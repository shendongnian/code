    public static class Extensions
    {
        public static bool TryParse<T>(this string source, out T result)
            where T : struct
        {
            result = default(T);
            var method = typeof (T)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .First(x => x.Name == "TryParse" && x.GetParameters()
                .Any(p => p.ParameterType.IsAssignableFrom(typeof(string))));
            bool isValid =  (bool)method
                .Invoke(null, new object[] {source, result});
            if (isValid) return true;
            return false;
        }
    }
    public static T GetNumberFromUser<T>(string Info)
        where T : struct
    {
        T TheDesiredNumber = default(T);
        while (true)
        {
            Console.Write("Please type " + Info + " : ");
            if (Console.ReadLine().TryParse<T>(out TheDesiredNumber))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" - " + Info + " is set to " + TheDesiredNumber.ToString() + "!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return TheDesiredNumber;
            }
            WrongInput(" - Invalid input!");
    }
