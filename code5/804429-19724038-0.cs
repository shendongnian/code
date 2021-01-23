    public static string ToString(this NameValueCollection nvc, int idx)
    {
         if(nvc == null)
             throw new NullReferenceException();
         string key = nvc[idx];
         if(nvc.HasKeys() && !string.IsNullOrEmpty(key))
         {
             return string.Concat(key, nvc.Get(key)); //maybe want some formatting here
         }
         return string.Empty;
    }
