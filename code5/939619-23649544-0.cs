     columns.Bound(m => m.PayManagerId).Width(150).Title("PM")
     .Template(p =>   p.PayManager).EditorTemplateName("PayManagerDropDown")
     .ClientTemplate("#:PayManagerId.FullName#");
    *****Grid Model ****************
    
    public class TestDirectoryDetail{
    
       public PayManagerListModel  PayManagerId {get; set;}
    
    }
    
    public PayManagerListModel  {
    
    public int userid       {get; set;}
    public string FullName  {get; set;}
    
    }
