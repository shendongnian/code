    private List<Pendulum> pendulums;
    
    void frmPendulum_Shown(object sender, EventArgs e)
    {
        // initialize the range for tbrPend
        tbrPend.Maximum = tbrNoOfPend.Value;
        
        pendulums = new List<Pendulum>(tbrNoOfPend.Maximum);
        for (int i = 0; i < tbrNoOfPend.Value; i++)
        {
            pendulums.Add(new Pendulum(this.Width + i * 40, this.ClientRectangle.Height, 0, 0, 0, 0, 0));
        }
        timer = new Timer()
        {
            Interval = 100
        };
        timer.Tick += delegate(object s2, EventArgs e2)
        {
            this.SuspendLayout();
            this.Refresh();
            this.ResumeLayout();
            Pendulum.length = tbrLength.Value; //means length is changed on all pendulums
            updateValueVisuals();
        };
        timer.Start();
    }
