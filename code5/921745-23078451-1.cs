    class DataStuff {
      ...
      // M is null; an instance should be created 
      // Usually, "private set;" instead of "set" is a better design
      public double[,] M { get; set; } 
 
      public DataStuff() {
        M = new Double[2, 2]; // <- M is created in the constructor
      } 
      ...
    }
    ...
    DataStuff test = new DataStuff();
    test.UpdateMatrixData(); 
    
