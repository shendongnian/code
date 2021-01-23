    btnOne.Click += new EventHandler(this.HandleButtonClick); 
    btnTwo.Click += new EventHandler(this.HandleButtonClick); 
    btnThree.Click += new EventHandler(this.HandleButtonClick);
     
    protected void HandleButtonClick(object sender, EventArgs e) 
    {
        Button clickedButton = (Button)sender;
        clickedButton.Enabled = false;
        ...
        clickedButton.Enabled = true; 
    }
