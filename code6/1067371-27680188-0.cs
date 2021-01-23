    public class MyData
    {
        public string FirstName { get; set; }
        public string UserName { get; set; } 
        // And so on and so forth for the other properties to save.
    }
    protected void btnSubmit_click(object sender, EventArgs e)
    {  
        MyData md = new MyData();
        md.FirstName = txtFName.Value;
        md.UserName = txtUName.Value;
        // And so on and so forth for the other controls.
        Session["MyData"] = md;  
    }
