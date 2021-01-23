    public abstract class ResourceInstance<TBase, TActual>
    {
       private static TBase _instance;
       public static TBase Instance
       {
           get
           {
               if (_instance == null)
                  _instance = (T)Application.Current.TryFindResource(typeof(TActual).Name);
               
               return _instance;
           }
       }
    }
