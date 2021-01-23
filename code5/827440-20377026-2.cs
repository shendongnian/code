    private void startButton_Click(object sender, EventArgs e) {
       //all the code you already had go first...
       startButton.Enabled = false;
    }
    void myPictureBox_MouseClick(object sender, MouseEventArgs e) {
       //...
       if(i == 0) p1 = point;
       else { 
          p2 = point;
          startButton.Enabled = true;
       }
       i++;
    }
