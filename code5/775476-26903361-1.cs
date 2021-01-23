            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _selecting = true;
                    _selection = new Rectangle(new Point(e.X, e.Y), new Size());
                }
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left && _selecting)
                {
                    // Create cropped image:
                    try
                    {
                        Image img = pictureBox1.Image.Crop(_selection);
    
    
                        // Fit image to the picturebox:
                        pictureBox1.Image = img.Fit2PictureBox(pictureBox1);
                    }
                    catch { }
                    _selecting = false;
                }
            }
    
            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                // Update the actual size of the selection:
                if (_selecting)
                {
                    _selection.Width = e.X - _selection.X;
                    _selection.Height = e.Y - _selection.Y;
    
                    // Redraw the picturebox:
                    pictureBox1.Refresh();
                }
            }
    
            private void pictureBox1_Paint(object sender, PaintEventArgs e)
            {
                if (_selecting)
                {
                    // Draw a rectangle displaying the current selection
                    Pen pen = Pens.LightSkyBlue;
                    e.Graphics.DrawRectangle(pen, _selection);
                }
            }
