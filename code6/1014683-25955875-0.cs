    private void timer1_Tick(object sender, EventArgs e)
    {
    // Go to point 1  
    // Go to point 2 
    // Go to point 3
    }
    private void form_Paint(object sender, PaintEventArgs e)
    {
        // caculation postition next HAS TO BE REMOVED FROM HERE
        mycircle.Draw(e.Graphics)
        // Invalidate(); HAS TO BE REMOVED FROM HERE
    }
