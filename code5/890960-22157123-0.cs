    private List<Point> points = new List<Point>();
    
    private void pbxCanvas_MouseDown(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            ActivePaint = true;
        }
    }
    
    private void pbxCanvas_MouseUp(object sender, MouseEventArgs e) {
        ActivePaint = false;
        points.Clear();
    }
    
    private void pbxCanvas_MouseMove(object sender, MouseEventArgs e) {
        if (ActivePaint) {
            points.Add(e.Location);
            Refresh();
        }
    }
    
    private void pbxCanvas_Paint(object sender, PaintEventArgs e) {
        using (var graphics = Graphics.FromImage(pbxCanvas.Image)) {
            for (int i = 0; i < points.Count - 1; i++) {
                graphics.DrawLine(Pens.Black, points[i], points[i + 1]);
            }
        }
    }
