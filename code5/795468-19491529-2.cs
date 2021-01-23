    internal static class DataSources
    {
         private static BindingSource bs;
    
         public static BindingSource CerateDataSource(List<object> yourObjects)
         {
              bs = new BindingSource();
              bs.DataSource = yourObjects;
         }
    
         public static BindingSource GetDataSource()
         {
              return bs;
         }
         
         public static void Reset()
         {
              bs.ResetBindings(false);
         }
    }
