    public class YourViewModel(IWindowManager winMan){
     private readonly IWindowManager _winMan;
     public YourViewModel(){
       _winMan = winMan;
     }
     public void DeleteCustomer(){
       var dialog= new DialogViewModel(); // not best way but...
       var settings = new Dictionary<string, object>();
       settings["Owner"] = this;
       settings["StartupLocation"] = WindowStartupLocation.CenterParent;
       _winMan.ShowDialog(dialog, null, settings);
      
       if(dialog.Result)
          //do delete
       else
          //do nothing
     }
    
    }
