    public void Process(string myString1, int myInt1, DateTime date = default(DateTime))
    {
         Type type = this.GetType();
         var flags =  BindingFlags.NonPublic | BindingFlags.Instance;
         var method = type.GetMethod("ImAChildMethod", flags);
         if(method.GetParameters().Length == 2)
         {
             type.InvokeMember("ImAChildMethod", System.Reflection.BindingFlags.InvokeMethod
                                               | System.Reflection.BindingFlags.NonPublic 
                                               | System.Reflection.BindingFlags.Instance,
                                               null, 
                                               this, 
                                               new object[] { myString1, myInt1  });
         } 
         else
         {
             type.InvokeMember("ImAChildMethod", System.Reflection.BindingFlags.InvokeMethod
                                               | System.Reflection.BindingFlags.NonPublic 
                                               | System.Reflection.BindingFlags.Instance,
                                               null, 
                                               this, 
                                               new object[] { myString1, myInt1,vdate  });
         }
    }
