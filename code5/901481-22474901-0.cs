    [Serializable]
    [SqlUserDefinedAggregate(Format.Native)]
    public struct Bitwise_or
    {
      //Implement the function below
      // Initialize any reource here, called once
      public void Init()
      {
      }
      // Decides what action to take for each row value
      public void Accumulate()
      {
      }    
      // Used by SQL Server when large amount of data is processed
      public void Merge()
      {
      }    
      // Free up resources
      public void Terminate()
      {
      }    
    }
