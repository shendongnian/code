    class A
    {
      int x;
      List<B> list;
    
      class B
      {
        B(A instance)
        {
          // Access x here using A.x;
        }
      }
      
      public void AddToList()
      {
         list.Add(new B(this));
      }
    }
