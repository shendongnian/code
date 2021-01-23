    private void Form1_Load_1(object sender, EventArgs e)
    {
        //Soon as the forms loads activate the goblin to start moving 
        //set the intial direction
        horiz = 1;  //start going right
        vert = 1;   //start going down
        step = 5;   //moves goblin 5 pixels
        timer1.Tick += timer1_Tick_1;
        // temporary timer
        Timer timer2 = new Timer();
        timer2.Interval = 5000;
        timer2.Tick += delegate
        {
            // activate goblin timer
            timer1.Enabled = true;
            // deactivate 5s temp timer
            timer2.Enabled = false;
            timer2.Dispose();
        };
        timer2.Enabled = true;
    }
