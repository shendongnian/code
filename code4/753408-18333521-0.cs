    public class MyClass {
        public int Value { get; set; }
        public bool IsValid { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            const int count = 10000000;
            const int percentageInvalid = 90;
            var rnd = new Random();
            var myCollection = new List<MyClass>(count);
            for (int i = 0; i < count; ++i) {
                myCollection.Add(
                    new MyClass {
                        Value = rnd.Next(0, 50),
                        IsValid = rnd.Next(0, 100) > percentageInvalid
                    }
                );
            }
            var sw = new Stopwatch();
            sw.Restart();
            int result1 = myCollection.Where(mc => mc.IsValid).Select(mc => mc.Value).Sum();
            sw.Stop();
            Console.WriteLine("Where + Select + Sum:\t{0}", sw.ElapsedMilliseconds);
            sw.Restart();
            int result2 = myCollection.Select(mc => mc.IsValid ? mc.Value : 0).Sum();
            sw.Stop();
            Console.WriteLine("Select + Sum:\t\t{0}", sw.ElapsedMilliseconds);
            Debug.Assert(result1 == result2);
            sw.Restart();
            int result3 = 0;
            foreach (var mc in myCollection) {
                if (mc.IsValid)
                    result3 += mc.Value;
            }
            sw.Stop();
            Console.WriteLine("foreach:\t\t{0}", sw.ElapsedMilliseconds);
            Debug.Assert(result2 == result3);
        }
    }
