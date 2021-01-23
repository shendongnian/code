         CloudTable table = tableClient.GetTableReference("xyztable");
         List<string> pkList = new List<string>(); // Partition keys to query
         pkList.Add("1");
         pkList.Add("2");
         pkList.Add("3");
         Parallel.ForEach(
            pkList,
            //new ParallelOptions { MaxDegreeOfParallelism = 128 }, // optional: limit threads
            pk => { ProcessQuery(table, pk); }
         );
