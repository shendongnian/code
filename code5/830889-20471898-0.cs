    public class BigData
    {
      private string _someValue;
      private DataSet _bigDataSet;
      public BigData()
      {
          ...
      }
      public BigData(BigData toBeCloned)
      {
         this._someValue = toBeCloed._someValue;
         // Don't copy _bigDataSet here!
      }
    }
