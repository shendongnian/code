    Timer timer1 = new Timer();
    int counter = 0;
    int dir = 1;
    int secondsToWait = 5;
    int speed1 = 25;
    int speed2 = 4;
    private void button1_Click(object sender, EventArgs e)
    {
        dir = speed2;
        timer1.Tick += timer1_Tick;
        timer1.Interval = speed1;
        timer1.Start();
        button1.Text = "Fade In";
    }
    void timer1_Tick(object sender, EventArgs e)
    {
        if (dir == 0)
        {
            timer1.Stop(); 
            dir = -speed2;
            counter = 254;
            button1.Text = "Fade Out";
            timer1.Interval = speed2;
            timer1.Start();
        }
        int alpha =  Math.Min(Math.Max(0, counter+= dir), 255);
        if (counter >= 255)
        { 
            timer1.Stop(); 
            button1.Text = "Wait";
            timer1.Interval = secondsToWait * 1000;
            dir = 0;
            timer1.Start();
        }
        else if (counter <= 0)
        {
            if ( !changeImage() ) 
               {
                 timer1.Stop(); 
                 button1.Text = "Done";
               }
            dir = speed2;
        }
        Color col = Color.FromArgb(255 - alpha, pan_image.BackColor);
        pan_layer.BackColor = col;
        pan_layer.Refresh();
    }
