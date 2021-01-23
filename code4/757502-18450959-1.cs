        private void DoStuff()
        {
            const int Iterations = 10000000;
            var classes = new List<CoordClass>();
            var structs = new List<CoordStruct>();
            var sw = new Stopwatch();
            while (true)
            {
                TimeSpan createTimeStruct = TimeSpan.Zero;
                TimeSpan createTimeClass = TimeSpan.Zero;
                classes.Clear();
                structs.Clear();
                // force garbage collection so that it doesn't happen
                // in the middle of things.
                GC.Collect();
                GC.WaitForPendingFinalizers();
                sw.Reset();
                sw.Start();
                for (var i = 0; i < Iterations; i++)
                {
                    var start = sw.Elapsed;
                    var c = new CoordClass(23, 24);
                    var stop = sw.Elapsed;
                    createTimeClass += (stop - start);
                    classes.Add(c);
                }
                sw.Stop();
                Console.WriteLine("Classes: {0} ms ({1})", sw.ElapsedMilliseconds, createTimeClass.TotalMilliseconds);
                sw.Reset();
                sw.Start();
                for (var i = 0; i < Iterations; i++)
                {
                    var start = sw.Elapsed;
                    var c = new CoordStruct(23, 24);
                    var stop = sw.Elapsed;
                    createTimeStruct += (stop - start);
                    structs.Add(c);
                }
                sw.Stop();
                Console.WriteLine("Structs: {0} ms ({1})", sw.ElapsedMilliseconds, createTimeStruct.TotalMilliseconds);
                Console.WriteLine("===================");
            }
        }
