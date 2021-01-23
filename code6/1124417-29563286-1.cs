        static void Main(string[] args)
        {
            DoSomething<ConsoleKey>();
            Console.ReadKey(true);
        }
        public static T DoSomething<T>() where T : struct, IConvertible, IComparable, IFormattable
        {
            T pom1 = Enum.GetValues(typeof(T)).Cast<T>().Max();
            Console.WriteLine(pom1);
            //Cast to object to bypass bits of the type system...Nasty!!
            int pom4 = (int)(object)pom1;
            Console.WriteLine(pom4);
            //Use Convert
            int pom5 = Convert.ToInt32(pom1);
            Console.WriteLine(pom5);
            //Take advantage of passing a IConvertible
            int pom6 = pom1.ToInt32(System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(pom6);
            return pom1;
        }
