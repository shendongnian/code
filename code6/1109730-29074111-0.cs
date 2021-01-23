    public static class FormHandler
    {
       private static readonly Dictionary<string,Form> Instances = new Dictionary<string,Form>();
       public TForm CreateFrom<TForm>()
       {
          string typeName = typeof(TForm).FullName;
         if(Instances.ContainsKey(typeName))
         {
              return Instances[typeName]
         }
         else
         {
           // Create Instace with Activator.CreateInstance,
           // and bind the dispose event to remove the form from the collection 
           // on dispose . Also make sure that you unbind the dispose Event
           [...]
          }
    }
