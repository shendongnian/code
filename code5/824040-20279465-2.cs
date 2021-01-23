    public void DrawCircle_Paint(object sender, PaintEventArgs e) 
    { 
        Graphics gr = e.Graphics;
        using(Pen p = new Pen(Color.Black, 3))
        {
            gr.DrawEllipse(pen, 40, 45, 20, 20);
            gr.DrawEllipse(pen2, 30, 25, 38, 20); 
            gr.DrawEllipse(pen3, 35, 36, 68, 15); 
            gr.DrawEllipse(pen4, 50, 60, 67, 35); 
         }
    }
