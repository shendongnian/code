            Pen pen1 = new Pen(Color.Red);
            for (int i = 0; i < pb.Height; i+=2)
            {
                g.DrawLine(pen1, 0, i, pb.Width, i);
            }
