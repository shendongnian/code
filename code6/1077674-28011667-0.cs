           var sourceCollection = Source().ToObservable();
            
            var maxBufferCount = 5;
            var bufferedCollection = sourceCollection.Buffer(TimeSpan.FromSeconds(5), maxBufferCount, Scheduler.Default);
            bufferedCollection.Subscribe(col => 
                    {
                        Console.WriteLine("count of items is now {0}", col.Count);
                    });
            
            Console.ReadLine();
