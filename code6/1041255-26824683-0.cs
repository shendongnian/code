    public class HomeLoanViewModel
    {
      public Lead_Options leadOption { get; set; }       
      public Lead HomeLoanLead {get;set;}
      public String SelectedValue {get;set;}
      public HomeLoanViewModel()
      {
        this.leadOption= new Lead_Options();
        this.HomeLoanLead= new Lead();
      }
      public void Post(){
         //do all your post logic here
         if(SelectedValue > XYZ) //do this
      }
    }
