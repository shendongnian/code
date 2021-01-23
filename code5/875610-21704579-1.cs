            var queue = new ConsoleQueue();
            
            Task.Factory.StartNew(() =>
            {
                foreach (string value in blockingCollection.GetConsumingEnumerable())
                {
                    queue.Push(value);
                }
            });
