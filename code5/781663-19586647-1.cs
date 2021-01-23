    public class ViewModelLocator
    {            
       private static MainViewModel _main;    
            
       /// Initializes a new instance of the ViewModelLocator class.
    
       public ViewModelLocator()            
       {                
          _main = new MainViewModel();            
       }    
            
      /// Gets the Main property which defines the main viewmodel.            
        
      public MainViewModel Main
      {                
         get                
           {              
           return _main;                
           }            
      }        
   
    }
