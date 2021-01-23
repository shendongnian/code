    private void drawPoints()
    {
        this.SuspendLayout();
        using (Graphics g = this.CreateGraphics())
        {
            //if (g == null) { this.ResumeLayout(); return; } // # Uncomment this line if you want defansive checks
            using (Brush b = new SolidBrush(Color.Red))
            {
                const int radius = 15;
                for (int i = 0; i < PointList.Count; i++)
                {
                    g.FillEllipse(b, (int)(PointList[i].X - radius / 2.0), (int)(PointList[i].Y - radius / 2.0), radius, radius);
                }
            }
        }
        
        PointList.Clear();
        this.ResumeLayout();
    }
