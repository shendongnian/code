        const int totalElements = 1000;
            const int target = 1000;
            var value = Enumerable.Range(1, totalElements).OrderBy(dd => dd).ToList();
            var sw = new Stopwatch();
            var result = new List<int[]>();
            sw.Start();
            for (int i = 0; i < value.Count / 3; i++)
            {
                var a = value[i];
                if (a > totalElements / 3) break;
                for (int j = i + 1; j < value.Count / 2; j++)
                {
                    var b = value[j];
                    for (int k = j + 1; k < value.Count; k++)
                    {
                        var c = value[k];
                        if (a + b + c <= target)
                        {
                            var newR = new[] { a, b, c };
                            result.Add(newR);
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Time Taken: " + sw.Elapsed.TotalSeconds);
            Console.WriteLine("Total result count: " + result2.Count);   
