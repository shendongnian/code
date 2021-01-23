    public enum StabilityLevel
    {
        Unstable,
        Neutral,
        Stable
    }
    
    public enum WindspeedClass
    {
        Class1,
        Class2,
        Class3
    }
    
    public class Windrose
    {
      #region Fields
      // percentual value for given direction
      private short[][][] _percentage;        
      // average wind speed in wind speed class for given stability level        
      private float[][] _average;
      #endregion
      
      
      public Windrose()  {    ... initialization ...  }
      
      #region Properties
      
      public string Name { get; set; }
      public int NumberOfDirections { get; set; }
      public StabilityLevel StabilityLevel { get; set; }
      public WindspeedClass Windspeed { get; set; }
    
      // indexer  
      public short this[StabilityLevel stability, WindspeedClass windspeedClass, int direction]
      {
          get
          {                
              return _percentage[(int) stability][(int) windspeedClass][direction];
          }
          set
          {
              _percentage[(int)stability][(int)windspeedClass][direction] = value;
          }
      }  
          
      #endregion    
                
    }
