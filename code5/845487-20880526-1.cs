    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            modal.Show();
        }
    
        protected void CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            ResetOptions();
            switch(radioButton.ID)
            {
                case "rdboption1":
                    rdboption11.Visible = true;
                    rdboption12.Visible = true;
                    break;
                case "rdboption2":
                    rdboption21.Visible = true;
                    rdboption22.Visible = true;
                    break;
            }   
        }
    
        private void ResetOptions()
        {
            rdboption11.Visible = false;
            rdboption12.Visible = false;
            rdboption21.Visible = false;
            rdboption22.Visible = false;
        }
    }
