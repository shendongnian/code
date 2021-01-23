        TxtCount.Text = count.ToString();
                for (int i = 0; i < count; ++i)
                {
                    PictureBox pb = new PictureBox();
                    pb.Location = new Point((80 * i) + 5, 30);
                    pb.Size = new Size(75, 75);
                    pb.BorderStyle = BorderStyle.Fixed3D;
                    pb.ImageLocation = "";
                    this.Controls.Add(pb);
                    pb.BringToFront();
                };
