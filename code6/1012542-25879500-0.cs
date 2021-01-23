    public partial class Test : System.Web.UI.Page
    {
       ... Same as above
    
        private void LoadControl()
        {
            phContent.Controls.Clear();
            var control = Page.LoadControl((String)HttpContext.Current.Session["control"]);
            control.ID = "1"; <--- 1. Control ID is required. 
            phContent.Controls.Add(control);
        }
    }
    
    public partial class Numbers : System.Web.UI.UserControl
    {
        // public override String ID ... <--- 2. Remove this
    
        protected void SelectNumbers_IndexChanged(object sender, EventArgs e)
        {
            lblSelectedNumber.Text = ((DropDownList)sender).SelectedItem.Text;
        }
    }
    
    public partial class Letters : System.Web.UI.UserControl
    {
        // public override String ID ... <--- 3. Remove this
    
        protected void SelectLetters_IndexChanged(object sender, EventArgs e)
        {
            lblSelectedLetter.Text = ((DropDownList)sender).SelectedItem.Text;
        }
    }
