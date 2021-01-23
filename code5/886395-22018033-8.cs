    public class CreateJobVM
    {
      public int IncidentID { set;get;}
      public int ActionTypeID { set;get;}
      public List<SelectListItem> ActionTypes { set;get;}
      public List<SelectListItem> Incidents{ set;get;} 
      public CreateJobVM()
      {
        ActionTypes =new List<SelectListItem>();
        Incidents=new List<SelectListItem>();
      }
    }
