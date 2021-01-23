    public class UserGoalsStepViewModel{  
     
      // in the ctor initiailze properites...
      public string SelectedValue {get;set;}
      public IEnumerable<SelectListItem> DDL {get;set;}
    public void Post(){
        DoSomethingWith(SelectedValue)
    }
