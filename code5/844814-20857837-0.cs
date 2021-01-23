    double progress = 0d;
    private void timer2_Tick(object sender, EventArgs e)
    { 
        progress += 0.01d; //Increment of progress
        label1.Text = progress.ToString(); // Converts progress to string
        this.Update(); // Redraws form. Needed because timer is too fast for 60fps.
    }
