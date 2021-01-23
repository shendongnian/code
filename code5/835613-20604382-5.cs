    namespace WebApplication1
    {
        public partial class dropdown : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
             {
             for (int i = 1; i < ddlState.Items.Count; i++)
            {
                var control = ddlState.Items[i].Value;
                this.FindControl(control).Visible = false;
            }
            
            string item = ddlState.SelectedValue;
            this.FindControl(item).Visible = true;
        }
    }
