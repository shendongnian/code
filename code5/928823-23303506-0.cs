    private void timer1_Tick_1(object sender, EventArgs e)
    {
        var timeElapsed = (DateTime.Now - startTime).TotalSeconds; // See if this is greater than 300       
    }
    private void Form1_Load_1(object sender, EventArgs e)
    {
        //Soon as the forms loads activate the goblin to start moving 
        //set the intial direction
        horiz = 1;  //start going right
        vert = 1;   //start going down
        step = 5;
        timer1.Enabled = true;
        timer1.Start();
        startTime = DateTime.Now;
    }
