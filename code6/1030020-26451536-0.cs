    //initializing timer
    rotationTimer = new Timer();
    rotationTimer.Interval = 150;    //you can change it to handle smoothness
    rotationTimer.Tick += rotationTimer_Tick;
    
    //create pictutrebox events
    pictureBox1.MouseEnter += pictureBox1_MouseEnter;
    pictureBox1.MouseLeave += pictureBox1_MouseLeave;
