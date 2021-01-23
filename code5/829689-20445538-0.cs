    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
            {
                label4.Visible = true;
                label4.Text = String.Format("X: {0}; Y: {1}", e.X, e.Y);
                if (panning)
                {
                    movingPoint = new Point(e.Location.X - startingPoint.X,
                                            e.Location.Y - startingPoint.Y);
                    pictureBox1.Invalidate();
                }
                if (checkBox2.Checked && e.Button == MouseButtons.Left)
                {
                    gp.AddLine(e.X * xFactor, e.Y * yFactor, e.X * xFactor, e.Y * yFactor);
                    pixelscounter += 1;
                    if (pixelscounter == 10)
                    {
                        redgp.AddEllipse((e.X) * xFactor, (e.Y) * yFactor, 3f, 3f);
                        pixelscounter = 0;
                    }
                    p = e.Location;
                    pictureBox2.Invalidate();
                }
                
            }
