            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                var file = new System.IO.FileInfo(@"c:\temp\file");
            }
            var t1 = sw.ElapsedMilliseconds;
            var args = new object [] { @"c:\temp\file" };
            sw.Restart();
            for (int i = 0; i < 100000; i++)
            {
                var file = Activator.CreateInstance(typeof(System.IO.FileInfo), args);
            }
            var t2 = sw.ElapsedMilliseconds;
            Console.WriteLine("t1: {0}", t1);
            Console.WriteLine("t2: {0}", t2);
