    public static class Storage
    {
         public static void SessionAdd(string label, string content)
         {
             if(string.IsNullOrEmpty(label) || string.IsNullOrEmpty(content))
                  return;
     
             HttpContext.Current.Session.Add(label, content);
         }
    
         public static void SessionPurge()
         {
             var context = HttpContext.Current;
             if(context.Session != null)
                  context.Session.Clear();
         }
    }
