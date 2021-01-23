    class WebServiceClass : Interface1, Interface2
    {
      public string Method1(int result) { ... }
      public void Method2(long id, int p3) { ... } 
      public void Method3(long in) { ... } 
    
      string Interface1.Method1(int result) { return Method1(result); }
      void Interface1.Method2(long id, int p3) { Method2(id, p3); }
      string Interface2.Method1(int result) { return Method1(result); } 
      void Interface2.Method2(long in) { Method3(in); }
    }
