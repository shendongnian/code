    //Declare a private property - you can adjust the access level of course,
    //depending on what you need.
    //You can even declare a field variable for the same cause,such as
    //private UserControl _myUserControl;
    //This declaration is in the class body.
    private UserControl MyUserControl { get; set; }
    
    //Your addition callback function.
    private void btnadd_Click(object sender, EventArgs e)
    {
        //The user control is now assigned to the property.
        MyUserControl = new UserControl1();
    
        pnlUI.SuspendLayout();
        pnlUI.Controls.Clear();
        pnlUI.Controls.Add(MyUserControl);
        pnlUI.ResumeLayout(false);
    }
    
    //Your removal callback function.
    private void btnremove_Click(object sender, EventArgs e)
    {
        //...
        //Use the property value here.
        pnlUI.Controls.Remove(MyUserControl);
        //...
    }
