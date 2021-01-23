            // Setup task and continuation
            var t1 = new Task(() =>
            {
                Console.WriteLine("TASK Starting");
                Task.Delay(1000).Wait();     // actual work here
                Console.WriteLine("TASK Finishing");
            });
            var t2 = t1.ContinueWith((x) =>
            {
                Console.WriteLine("C1");
                Task.Delay(100).Wait();      // actual work here
                Console.WriteLine("C2");
            });
            t1.Start();
            
            // Exception will be swallow without the line below
            await Task.WhenAll(t1, t2);
