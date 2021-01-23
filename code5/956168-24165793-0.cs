      private void IncreaseSize(PictureBox p,int dt)
            {
                Size size = p.Size;
                size.Height = size.Height + dt;
                size.Width=size.Width + dt;
                p.Size = size;
               
            }
    
            private void DecreaseSize(PictureBox p, int dt)
            {
                Size size = p.Size;
                size.Height = size.Height - dt;
                size.Width = size.Width - dt;
                p.Size = size;
            }
