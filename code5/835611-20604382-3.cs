    namespace WebApplication1
    {
        public partial class dropdown : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
             {
            var control = ddlState.SelectedValue;
                this.FindControl(control).Visible = false;
            
            //show the selected dropdown list panel
            string item = ddlState.SelectedValue;
            this.FindControl(item).Visible = true;
        }
    }
