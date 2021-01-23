    _collection = new BlockingCollection<List<UserInfo>>(); //BlockingCollection contains list of 5000 user for example
    var consumer = Task.Factory.StartNew(() =>
    {
        Parallel.ForEach(Partitioner.Create(_collection.GetConsumingEnumerable()), new ParallelOptions() { MaxDegreeOfParallelism = 10}, (partOfCollection) =>
        {
            DoSomethingWithList(partOfCollection); //in this function you loop the list of userinfo and run the 'FunctionToCall' method
        }
    }
    //Add users in blocks of 5000 to the collection
    _collection.Add(firstPartOfUserInfo);
    _collection.Add(secondPartOfUserInfo);
        
    _collection.CompleteAdding();
    consumer.Wait();
