    Timer timer1 = new Timer();
    int imageIndex = 0;
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (imageIndex >= imageList1.Images.Count ) timer1.Stop(); 
        label1.Image = imageList1.Images[imageIndex++]; 
    }
    
    
    private void button1_Click(object sender, EventArgs e)
    {
       imageIndex = 0;
       timer1.Interval = 100; // change ms to suit your needs!
       timer1.Start();              
    }
