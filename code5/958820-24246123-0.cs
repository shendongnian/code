        RadioButton jumper = new RadioButton();
        jumper.Location = new System.Drawing.Point(10, 20);//x,y axis
        jumper.Size = new System.Drawing.Size(80, 30); //width,height
        jumper.Text = "Jumper";
        RadioButton shortPin = new RadioButton();
        shortPin.Location = new System.Drawing.Point(100, 20);//x,y axis
        shortPin.Size = new System.Drawing.Size(80, 30); //width,height       
        shortPin.Text = "Short";
        this.Controls.AddRange(new Control[] { shortPin, jumper});
