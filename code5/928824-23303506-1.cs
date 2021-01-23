    int horiz, vert, step;
    DateTime startTime;
    public Form1()
    {
        InitializeComponent();
    }
    private void timer1_Tick_1(object sender, EventArgs e)
    {
        var timeElapsed = (DateTime.Now - startTime).TotalSeconds; // Show image if this is greater than 300       
        //image is moved at each interval of the timer
        goblin.Left = goblin.Left + (horiz * step);
        goblin.Top = goblin.Top + (vert * step);
        // if goblin has hit the RHS edge, if so change direction left
        if ((goblin.Left + goblin.Width) >= (Form1.ActiveForm.Width - step))
            horiz = -1;
        // if goblin has hit the LHS edge, if so change direction right
        if (goblin.Left <= step)
            horiz = 1;
         // if goblin has hit the bottom edge, if so change direction upwards
        if ((goblin.Top + goblin.Height) >= (Form1.ActiveForm.Height - step))
            vert = -1;
        // if goblin has hit the top edge, if so change direction downwards
        if (goblin.Top < step)
            vert = 1;
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
