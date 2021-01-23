            List<Guid> listA = new List<Guid>();
            for (int count = 0; count < 10000; count++)
            {
                listA.Add(Guid.NewGuid());
            }
            List<Guid> listB = new List<Guid>();
            for (int count = 0; count < 10000; count++)
            {
                listB.Add(Guid.NewGuid());
            }
            // Match by Any without matches.
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool matchFound = listA.Any(item => listB.Contains(item));
            sw.Stop();
            Console.WriteLine("List Match {0}ms", sw.ElapsedMilliseconds);
            System.Collections.Generic.Dictionary<Guid, string> dictA = new System.Collections.Generic.Dictionary<Guid, string>();
            for (int count = 0; count < 10000; count++)
            {
                dictA.Add(Guid.NewGuid(),"");
            }
            // Match by Key without matches.
            sw.Reset();
            sw.Start();
            matchFound = listB.Any(item => dictA.ContainsKey(item));
            sw.Stop();
            Console.WriteLine("Key Match {0}ms", sw.ElapsedMilliseconds);
