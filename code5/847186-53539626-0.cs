    public class DataGridViewBoolCell : DataGridViewImageCell
    {
      protected bool YourProperty{ get; private set; }
    
      public DataGridViewBoolCell( bool yourParameter )
      {
        YourProperty = yourParameter;
      }
    
      public override object Clone()
      {
        var cloned = base.Clone();
        ((DataGridViewBoolCell)cloned).YourProperty = YourProperty;
        return cloned;
      }
    }
