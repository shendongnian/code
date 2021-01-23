      WebUserControl1.SubmitButtonClick+= 
		new WebUserControl.EventHandler(WebUserControl1_SubmitButtonClick);
     private void WebUserControl1_SubmitButtonClick(object sender, EventArgs e)
    {
        Label1.Text = "Button Pressed";
    }
