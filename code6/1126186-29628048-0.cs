        private static void Main(string[] args) {
            string input = "[2015-04-14 13:45:00]Aeon///Test///Aeon : this is my/// test message///S1";
            const string sep = "///";
            int first = input.IndexOf(sep, System.StringComparison.Ordinal);
            int second = input.IndexOf(sep, first + sep.Length, System.StringComparison.Ordinal);
            int last = input.LastIndexOf(sep, System.StringComparison.Ordinal);
            int dl = "[2015-04-14 13:45:00]".Length;
            Console.WriteLine(input.Substring(dl, first - dl));
            Console.WriteLine(input.Substring(first + sep.Length, second - first - sep.Length));
            Console.WriteLine(input.Substring(second + sep.Length, last - second - sep.Length));
            Console.WriteLine(input.Substring(last + sep.Length, input.Length - last - sep.Length));
        }
