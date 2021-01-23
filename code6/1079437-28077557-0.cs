    public partial class ParentPage: System.Web.UI.Page
    {
      private  Control ucUserControl;
      protected void Page_Load(object sender, System.EventArgs e)
      {
        ucUserControl =(Control)Page.LoadControl("control1.ascx");
        placeholder.Controls.Add(ucUserControl);
 
       }
       //button click event 
       protected void button_Click(object sender, EventArgs e)
       {
         ucUserControl.ActionMethod();
       }
    }
