        static void Main(string[] args)
        {
            var loopLength = 100000000;
            var d = new Dictionary<int, int>();
            for (var i = 0; i < 5000000; i++)
            {
                d.Add(i, i + 5);
            }
            var ignore = d[7];
            var a = new int[5000000];
            for (var i = 0; i < 5000000; i++)
            {
                a[i] = i + 5;
            }
            ignore = a[7];
            var r = new Random();
            var s = new Stopwatch();
            s.Start();
            for (var i = 0; i < loopLength; i++)
            {
                var x = r.Next(5000000);
            }
            s.Stop();
            var randomTime = s.ElapsedMilliseconds;
            Console.WriteLine(s.ElapsedMilliseconds);
            s.Reset();
            s.Start();
            for (var i = 0; i < loopLength; i++)
            {
                var x = r.Next(5000000);
                var y = d[x];
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds - randomTime);
            s.Reset();
            s.Start();
            for (var i = 0; i < loopLength; i++)
            {
                var x = r.Next(5000000);
                var y = a[x];
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds - randomTime);
            Console.ReadKey(true);
        }
