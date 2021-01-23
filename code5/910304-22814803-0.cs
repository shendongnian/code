    var delay = Observable.Empty<IList<int>>().Delay(TimeSpan.FromSeconds(10));
    var query = Observable.Range(0, 100000)
                          .Buffer(20)
                          .Select(batch => Observable.Return(batch).Concat(delay))
                          .Concat();
    query.Subscribe(list =>
                        {
                            Console.WriteLine(DateTime.Now);
                            foreach (var value in list)
                            {
                                Console.WriteLine(value);
                            }
                        });
