    public MyForm() 
    {
        this.Paint += this.PaintRectangles;
    }
    
    private void PaintRectangles(object sender, PaintEventArgs e)
    {
        // use e.Graphics to draw stuff
    }
