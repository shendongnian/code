        private void DoStuff()
        {
            const int Iterations = 10000000;
            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                var sw = Stopwatch.StartNew();
                var structs = new List<CoordStruct>();
                AddItems(structs, Iterations);
                sw.Stop();
                Console.WriteLine("Empty list: {0:N0} ms", sw.ElapsedMilliseconds);
                sw.Restart();
                structs = new List<CoordStruct>(Iterations);
                AddItems(structs, Iterations);
                sw.Stop();
                Console.WriteLine("Pre-allocated list: {0:N0} ms", sw.ElapsedMilliseconds);
                Console.WriteLine("===================");
            }
        }
        private void AddItems(List<CoordStruct> list, int nItems)
        {
            for (var i = 0; i < nItems; ++i)
            {
                list.Add(new CoordStruct(23, 24));
            }
        }
