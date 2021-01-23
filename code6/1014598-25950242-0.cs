    void SetGridLabel()
    {
        for (int i = 0; ; i++)
        {
            for (int j = 0; ; j++)
            {
                Label L = new Label();
                L.TextAlign = ContentAlignment.MiddleCenter;
                L.AutoSize = false;
                L.Size = new Size(70, 70);
                L.Text = "Test_" + j + "_" + i;
                L.Location = new Point(j * L.Size.Width, i * L.Size.Height);
    
                if ((i + 1) * L.Size.Height > this.Size.Height)
                    return;
                if ((j + 1) * L.Size.Width > this.Size.Width)
                    break;
                this.Controls.Add(L);
            }
    
        }
            
    }
