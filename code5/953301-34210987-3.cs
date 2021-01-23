        public static void IndendedPrintForEach<T>(this IEnumerable<T> array, string header, Func<T, string> consoleStringConverterMethod)
        {
            var list = array.ToList();
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"<<<{header}>>>");
            Console.ForegroundColor = color;
            if (!list.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("    ************NoItemsFound************");
                Console.ForegroundColor = color;
            }
            else
            {
                foreach (var item in list)
                    Console.WriteLine($"    {consoleStringConverterMethod(item)}");
            }
        }
