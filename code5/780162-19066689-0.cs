    //Create new instance of button
    Button btn = new Button();
    //Set button Location
    btn.Location = new Point(100, 200);
    //Set button event handler
    btn.Click += new EventHandler(btn_Click);
    //Add button to Form
    this.Controls.Add(btn);
    void btn_click (object sender, EventArgs e)
    {
        
    }
