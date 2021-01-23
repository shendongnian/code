        public IEnumerable<Product> Comparer(IEnumerable<Product> collection, IEnumerable<Product> target, string comparissonKey)
        {
            var count = 0;
            var stopWatch = new Stopwatch();
            var result = new ConcurrentBag<Product>();
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 };
            // create a dictionary for fast lookup
            var targetDictionary = target.ToDictionary(p => p.Key);
            Parallel.ForEach(collection, parallelOptions, obj =>
            {
                count++;
                if (count == 60000)
                {
                    stopwatch.Stop();
                    //breakpoint
                    var aux = stopwatch.Elapsed;
                }
                var comparableObj = obj;
                comparableObj.IsDifferent = false;
                bool hasTargetObject = false;
                comparableObj.Exist = true;
                Product objTarget = null;
                // lookup using dictionary
                if (targetDictionary.TryGetValue(obj.Key, out objTarget))
                {
                    //Do stuff
                }
                if (hasTargetObject) return;
                if (comparableObj.IsDifferent)
                {
                    //Do Stuff
                }
            });
            return result.ToList();
        }
