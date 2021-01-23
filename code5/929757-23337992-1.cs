    // all PictureBoxes in the array are null after the next statement:
    PictureBox[] picArray = new PictureBox[allFiles.Length]; 
    int y = 0;
    for (int i = 0; i < picArray.Length; i++ )
    {
        var newPictureBox = new PictureBox(); // this will initialize it 
        picArray[i] = newPictureBox;  // this will add it to the array 
        this.Controls.Add(newPictureBox);
        if(i%3 == 0){
            y = y + 150;
        }
        newPictureBox.Location = new Point(i*120 + 20 , y);
        newPictureBox.Size = new Size(100, 200);
        newPictureBox.Image = Image.FromFile(allFiles[i]);
    }
