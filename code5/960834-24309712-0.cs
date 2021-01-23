        int d = 50;
            var setA = Enumerable.Range(1, d / 3);
            var value = Enumerable.Range(1, d).OrderBy(dd => dd).ToList();
            var result = new List<int[]>();
            var sw = new Stopwatch();
            
            var result2 = new List<int[]>();
            sw.Start();
            for (int i = 0; i < value.Count/3; i++)
            {
                var a = value[i];
                if (a > d / 3) break;
                for (int j = i + 1; j < value.Count/2; j++)
                {
                    var b = value[j];
                    for (int k = j + 1; k < value.Count; k++)
                    {
                        var c = value[k];
                        if (a + b + c <= d)
                        {
                            var newR = new[] { a, b, c };
                                result2.Add(newR);
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Time Taken: " + sw.Elapsed.TotalSeconds);
            Console.WriteLine("Total result count: " + result2.Count);             
