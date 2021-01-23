      public void MyMethod()
      {
          {
            string x;
          }
          List sampleList = populateList();    
          foreach(MyType myType in sampleList)
          {
              string x;   // This will be fine.
              doSomethingwithX(x);
          }
       }
