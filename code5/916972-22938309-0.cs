            List<Task<T>> tasks = new List<Task<T>>();
            foreach (var i in integerArray)
            {
                tasks.Add(Task.Factory.StartNew<T>(() => {
                    string rowCompare = String.Format(CommonDefs.inverseTimeStampRowKeyFormat, DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
                    var result = (from er in this.serviceContext.EntityReportsTable
                                               where er.PartitionKey.Equals(i.ToString(), StringComparison.OrdinalIgnoreCase) && er.RowKey.CompareTo(rowCompare) > 0
                                               select er).Take(1)).FirstOrDefault();
                }));
            }
            Task.WaitAll(tasks.ToArray());
            foreach (var task in tasks)
            {
                var queryResult = task.Result;
                //Work on the query result
            }
