    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        var drawer = new MyTextDrawer(e.Graphics);
        drawer.DrawText("List points", Color.Red, Color.Green, new Point(369, 90), new Point(469, 90), new Point(480, 83),8.25);
        drawer.DrawText("List clouds1", Color.Black, Color.Green, new Point(369, 110), new Point(469, 110), new Point(480, 103),8.25);
    }
