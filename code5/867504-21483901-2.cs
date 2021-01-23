            List<MyClass> list = new List<MyClass>(1000);
            for (int i = 0; i < 100000; i++)
            {
                list.Add(new MyClass
                {
                    Code1 = i,
                    Code2 = i * 2,
                });
            }
            System.Diagnostics.Stopwatch timer1 = System.Diagnostics.Stopwatch.StartNew();
            var resultLinq = list.SelectMany(item => new[] { item.Code1, item.Code2 }).ToList();
            Console.WriteLine("Ani's: {0}", timer1.ElapsedMilliseconds);
            System.Diagnostics.Stopwatch timer2 = System.Diagnostics.Stopwatch.StartNew();
            var codes = new List<int>(list.Count * 2);
            foreach (var item in list)
            {
                codes.Add(item.Code1);
                codes.Add(item.Code2);
            }
            Console.WriteLine("Mine : {0}", timer2.ElapsedMilliseconds);
        }
