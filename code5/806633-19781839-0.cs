    for (int i = 0; i < ImagesInFolder.Count; i++) 
    {
        PictureBox I = new PictureBox(); //Initialize a new PictureBox of name I
        I.Location = new System.Drawing.Point(x, y); //Set the PictureBox location to x,y
        x += 50; //Sort horizontally; Increment x by 50
        //y += 50; //Sort vertically; Increment y by 50
        //Set the Image property of I to i in ImagesInFolder as index
        I.Image = ImagesInFolder[i]; 
        //Set the PictureBox Size property to 50,50
        I.Size = new System.Drawing.Size(80, 80); 
        //Stretch the image; maximum width and height are 50,50
        I.SizeMode = PictureBoxSizeMode.StretchImage; 
        //Add the Event handler to the click event
        I.Click += pictureBox_Click;
        flowLayoutPanel1.Controls.Add(I); //Add the PictureBox to the FlowLayoutPanel
    }
