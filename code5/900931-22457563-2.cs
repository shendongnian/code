    public static class ArrayExtension{
        public static T HasContent<T>(Array<T> array, T default) {
             if( array != null && array.Length >0 ){
                  return array[0];
             }
             else {
                  
             }
        }
    }
    int[] x = null;
    
    int y = x.HasContent(42); // 42
    
    string[] strs = new string[] {};
    
    string some = strs.HasContent("default"); // default
    
    string[] strs2 = new string[] {"foo", "bar" };
    
     string some2 = strs.HasContent("default"); // foo
