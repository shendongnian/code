    class ViewModel 
    {
      //Use Instance of Model in here
      public ViewModel() // OR pass model as dependency injection 
                         //so that you can use it for Unit Testing 
      {
        prop1 = DataModel.field1
        prop2 = DataModel.field2;
        prop3 = UtilityClass.complexFunction();
        ......
        //Do not put this Conversion of DataModel to Model assignment logic in 
        //View Model's constructor write mapper file or something to convert Data Model to Model   
      }
    }
