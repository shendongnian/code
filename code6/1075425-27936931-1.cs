        static void Main(string[] args)
        {
            var str = "foo,bar,test";
            Console.WriteLine(DoValuesMatch(str));
            Console.ReadLine();
        }
        private static bool DoValuesMatch(string str)
        {
            var strArr = str.Split(new[] { ',' });
            return strArr.Distinct().Count() == 1;
        }
