    private void t_Tick(object sender, EventArgs e)
    {
            complete++;
            graph = Graphics.FromImage(bmp);
            graph.Clear(Color.DarkGoldenrod);
            graph.FillRectangle(Brushes.ForestGreen, new Rectangle(0,0,(int)(complete * Unit),height));
            graph.DrawString(complete + "%", new Font("Papyrus", height / 3), Brushes.Black, new PointF(width / 2 - height, height / 10));
    
            picBoxPB.Image = bmp;
            
    
            if (complete>100)
            {
                graph.Dispose();
                t.Stop();
    
            }
    }
