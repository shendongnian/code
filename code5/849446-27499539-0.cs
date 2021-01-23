     protected override void OnInit(EventArgs e)
    {
        //find the button control within the user control
        Button button = (Button)WebUserControlTest.FindControl("btn1");
        //wire up event handler
        button.Click += new EventHandler(button_Click);
        base.OnInit(e);
    }
    
    void button_Click(object sender, EventArgs e)
    {
        TextBox txt = (TextBox) WebUserControlTest.FindControl("txtbox1");
       //id of lable which is present in the parent webform 
        lblParentForm.Text=txt.text; 
    }
