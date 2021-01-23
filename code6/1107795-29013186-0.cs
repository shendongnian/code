    try
    {
    
    }
    catch (exception ex)
    {
         using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@".\error.log",true))
         {
             sw.Write(String.Format("{0}/t {1}", DateTime.Now, ex.ToString()));
             sw.Write(String.Format("{0}/t {1}", DateTime.Now, ex.StackTrace.ToString()));
         }
    }
