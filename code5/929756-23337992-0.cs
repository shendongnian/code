    // all PictureBoxes in the array are null after the next statement:
    PictureBox[] picArray = new PictureBox[allFiles.Length]; 
    int y = 0;
    for (int i = 0; i < picArray.Length; i++ )
    {
        picArray[i] = new PictureBox();  // this will initialize it
        this.Controls.Add(picArray[i]);
        if(i%3 == 0){
            y = y + 150;
        }
        picArray[i].Location = new Point(i*120 + 20 , y);
        picArray[i].Size = new Size(100, 200);
        picArray[i].Image = Image.FromFile(allFiles[i]);
    }
