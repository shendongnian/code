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
            var s = new Stopwatch();
            var x = 1;
            s.Start();
            for (var i = 0; i < loopLength; i++)
            {
                x = (x * 1664525 + 1013904223) & (4194303);
                var y = d[x];
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            s.Reset();
            x = 1;
            s.Start();
            for (var i = 0; i < loopLength; i++)
            {
                x = (x * 1664525 + 1013904223) & (4194303);
                var y = a[x];
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadKey(true);
        }
