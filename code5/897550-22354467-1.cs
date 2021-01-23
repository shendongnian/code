    class MyDrawingBoard : System.Windows.Forms.Control
    {
        List<Ball> MyBalls = new List<Ball>();
        override void OnPaint(object sender, PaintEventArgs e)
        {
             foreach(var b in MyBalls)
             {
                 e.Graphics.DrawEllipse()...
             }
        }
    }
