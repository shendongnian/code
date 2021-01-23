    toolStripProgressBar2.Value = Math.Min(this.toolStripProgressBar2.Maximum,e.ProgressPercentage);
                                
            
    toolStripProgressBar2.ProgressBar.CreateGraphics().DrawString(e.ProgressPercentage.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(this.toolStripProgressBar2.Width / 2 - 10, this.toolStripProgressBar2.Height / 2 - 7));
    toolStripProgressBar2.PerformStep();
