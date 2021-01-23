    public class SampleViewModel : NotificationObject
    {  
      
      public class MyModel { get; set; }
      public class SampleViewModel()
      {
       MyModel = new MyModel() { SubHeaderText = "Sample" }; 
       RaisePropertyChange("MyModel");
      }  
    }
