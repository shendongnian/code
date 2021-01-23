    public static T? TryParse<T>(this string input) where T : struct {
       T i = default(T);                        
       object[] args = new object[] { input, i };
       var tryParse = typeof(T).GetMethod("TryParse", 
                                 new[] { typeof(string), typeof(T).MakeByRefType() });
       if(tryParse != null){
           var r = (bool) tryParse.Invoke(null, args);            
           return r ? (T) args[1] : (T?)null;
       }
       return (T?)null;
    }
    //Usage
    double? d = yourString.TryParse<double>();
    int? i = yourString.TryParse<int>();
