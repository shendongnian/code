    private static void InsertDataUsingObservableBulkCopy(IEnumerable<Person> people, 
                                                          SqlConnection connection)
    {
        var sub = new Subject<Person>();
        var bulkCopy = new SqlBulkCopy(connection);
        bulkCopy.DestinationTableName = "Person";
        bulkCopy.ColumnMappings.Add("Name", "Name");
        bulkCopy.ColumnMappings.Add("DateOfBirth", "DateOfBirth");
        using(var dataReader = new ObjectDataReader<Person>(people))
        {
            var task = Task.Factory.StartNew(() =>
            {
                bulkCopy.WriteToServer(dataReader);
            });
            var stopwatch = Stopwatch.StartNew();
            foreach(var person in people) sub.OnNext(person);
            sub.OnCompleted();
            task.Wait();
            Console.WriteLine("Observable Bulk copy: {0}ms",
                               stopwatch.ElapsedMilliseconds);
        }
    }
