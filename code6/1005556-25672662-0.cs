       public ClassA
        {
          private IClassB _classB;
    
           public ClassA(IClassB classB)
           {
              _classB = classB;
           }
    
           public void DoWork()
          {
             // first do some work
             //then call class b to do more work
                   _classB.DoOtherWork();
          }
        }
