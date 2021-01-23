    private void drawPoints()
    {
        this.SuspendLayout();
        const int radius = 15;
        using (Graphics g = this.CreateGraphics())
        {
            //if (g == null) { this.ResumeLayout(); return; } // # Uncomment this line if you want defensive checks
            using (Brush b = new SolidBrush(Color.Red))
            {
                for (int i = 0; i < PointList.Count; i++)
                {
                    g.FillEllipse(b, (int)(PointList[i].X - radius / 2.0), (int)(PointList[i].Y - radius / 2.0), radius, radius);
                }
            }
        }
        
        PointList.Clear();
        this.ResumeLayout();
    }
