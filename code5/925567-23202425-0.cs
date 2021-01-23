      void DoSomething() 
      {
          var theList = new List<IService>();
          for (int i = 1; i <= 3; i++)
          {
              //use this
              IService s = new Concrete(i); 
              //or this
              //IService s = new new Mock(i);
              theList.Add(s);
          }
    
          // do something with the list...
      }
