    public partial class MyControl: System.Web.UI.UserControl
    {
       public int ControlID
       {
         get
           {
            if(ViewState["ControlID"]==null)
               return 0;
            return int.Parse(ViewState["ControlID"].ToString()); 
           }
         set
          {
            ViewState["ControlID"] = value;
          }
       }
      ....
     }
 
