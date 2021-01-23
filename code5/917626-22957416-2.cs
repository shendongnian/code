    class ViewModel
    {
     private libModel _libModel;
     public libModel LibModel { get; set; }
     //after you set up your RoutedCommands
     //I declare method within my VM to handle the RoutedCommands don't know 
     //if it works when you use Property Method
     void VMMethod()
     {
          //use VM's property to invoke desired method from your lib
     }
    }
