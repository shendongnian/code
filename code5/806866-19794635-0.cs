    //use this extension method for convenience
    public static class BindingSourceExtension {
      public static void SuppressListChanged(this BindingSource bs, bool suppress){
         typeof(BindingSource).GetField("raiseListChangedEvents",
                                        System.Reflection.BindingFlags.NonPublic |
                                        System.Reflection.BindingFlags.Instance)
                              .SetValue(bs, !suppress);
      }
    }
    //Usage
    myBindingSource.SuppressListChanged(true);//suppress
    myBindingSource.Insert(5,someObject);
    myBindingSource.SuppressListChanged(false);//unsuppress
