    RadioButton jumper = new RadioButton();
    jumper.Location = new System.Drawing.Point(10, 20);//x,y axis
    jumper.Size = new System.Drawing.Size(80, 30); //width,height
    jumper.Text = "Jumper";
    
    RadioButton shortPin = new RadioButton();
    //change x-axis but keep same y-axis
    shortPin.Location = new System.Drawing.Point(100, 20);
    shortPin.Size = new System.Drawing.Size(80, 30); //width,height       
    shortPin.Text = "Short";
    
    this.Controls.AddRange(new Control[] { shortPin, jumper});
