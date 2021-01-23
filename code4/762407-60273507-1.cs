            var size = 200000;
            //First test sometimes has a bad count
            List<object> SomeList = new List<object>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Insert(i, String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds + " - Throw Away Run");
            sw.Reset();
            SomeList = new List<object>();
            sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size ; i++)
                SomeList.Insert(i, String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds+" - List Insert By Index without Capacity");
            sw.Reset();
            SomeList = new List<object>();
            sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Insert(0, String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds + " - List Insert At Index 0 without Capacity");
            sw.Reset();
            
            SomeList = new List<object>();
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Add(String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds+" - List Add without Capacity");
            sw.Reset();
            SomeList = new List<object>(size);
            sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Insert(i, String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds+" - List Insert By Index with Capacity");
            sw.Reset();
            SomeList = new List<object>(size);
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Add(String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds+" - List Add with Capacity");
            sw.Reset();
            SomeList = new List<object>(size);
            sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < size; i++)
                SomeList.Insert(0, String.Empty);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds + " - List Insert at Index 0 with Capacity");
