    IEnumerable<Data> LoadDataFromDatabase()
    { 
        return ...
    }
    void ProcessInParallel()
    {
       while(true)
       {
          var data = LoadDataFromDatabase().ToList();
          if(!data.Any()) break;
          
          data.AsParallel().ForEach(ProcessSingleData);
       }
    }
    void ProcessSingleData(Data d)
    {
      // do something with data
    }
