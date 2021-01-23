    class DataStuff {
      ...
      public double[,] M { get; set; } // <- M is null; an instance should be created 
 
      public DataStuff() {
        M = new Double[2, 2]; // <- M is created in the constructor
      } 
      ...
    }
    ...
    DataStuff test = new DataStuff();
    test.UpdateMatrixData(); 
  
    
