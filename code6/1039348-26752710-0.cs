    static void Main(string[] args)
        {
            string test = Tester().Result;
            Console.WriteLine(test);
        }
        public static async Task<string> Tester()
        {
            Task t = new Task(() => System.Threading.Thread.Sleep(2000));
            t.Start();
            await t;
            return "OK";
        }
