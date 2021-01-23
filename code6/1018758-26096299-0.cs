    protected void Page_PreRender(object sender, EventArgs e)
        {
            UpdateButton1()
            Thread.Sleep(10000); // no need to put sleep
            UpdateButton2();
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateButton1();
        }
    
        protected void UpdateButton1()
        {
            changeLabel.Text = "Button1";
        }
