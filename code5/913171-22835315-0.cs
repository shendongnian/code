        static void Main(string[] args)
        {
            DateTime? d0 = null;
            DateTime? d1 = new DateTime(2013, 1, 1);
            DateTime? d2 = new DateTime(2014, 1, 1);
            DateTime? d3 = new DateTime(2015, 1, 1);
            DateTime? d4 = null;
            List<DateTime?> dts = new List<DateTime?>() { d0, d1, d2, d3, d4 };
            //I finally replaced x with x.Value, and compile error disappeared
            var v = dts.Where(x => x.HasValue).OrderBy(x =>
                (Math.Abs((DateTime.Now - x.Value).TotalMilliseconds)));
            foreach (var x in v)
                Console.WriteLine(x);
            Console.ReadLine();
        }
