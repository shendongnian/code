    Stopwatch t = new Stopwatch();
                t.Start();
                var numbers = Enumerable.Range(2, (int)(500 * (Math.Log(500) + Math.Log(System.Math.Log(500)) - 0.5)))
                    .Where(x => Enumerable.Range(2, x - 2)
                                          .All(y => x % y != 0))
                    .TakeWhile((n, index) => index < 500);
                t.Stop();
                MessageBox.Show(t.ElapsedMilliseconds.ToString());
                MessageBox.Show(string.Join(",", numbers));
