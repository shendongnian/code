         public void method1(string s)
         {
            if(s!=null)
            {
                // do something with s here. 
                 String temp = s ; 
                 s = null ; 
                 method2(s) ; 
            }
      }
          public void method2(string s)
          {
                // do something with s
           }
