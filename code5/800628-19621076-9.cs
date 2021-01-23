    public class ViewModel_A1 : INotifyPropertyChanged
    {
      public Model_A instance;
      
      public ViewModel()
      {
         instance = new instance
         { //your mock value for the properties..
           FirstName = "Offer",
           LastName = "Somthing"
         };
      }
    
      public ViewModel(Model_A instance)
      { 
        this.instance = instance;
      }
    }
