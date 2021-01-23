    class A
    {
        public string helloworld()
        {
            return "A";
        }
    }
    
    class B : A
    {
        public new string helloworld()
        {
            return "B";
        }
    }
    
    class C: B
    {
       public string hi(bool condition)
       {
          if(condition)
          {
             A instance = this;
             return instance.helloworld(); // From class A
          }
          else
          {
              B instance = this;
              return instance.helloworld(); // From class B
          }
        }
    }
