            Button button = new Button();
            button.Name = "btn" + idDanych;
            button.Width = 100;
            button.Height = 100;
            button.Location = new Point(0, 0);
            button.Text = "";
            Bitmap bmp = new Bitmap(button.ClientRectangle.Width, button.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.Clear(button.BackColor);
                string line1 = "( " + Wieszak + " ) " + Haczyk;
                string line2 = KodEAN;
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Near;
                using (Font arial = new Font("Arial", 12))
                {
                    Rectangle RC = button.ClientRectangle;
                    RC.Inflate(-5, -5);
                    G.DrawString(line1, arial, Brushes.Black, RC, SF);
                }
                using (Font courier = new Font("MS Courier", 24))
                {
                    SF.LineAlignment = StringAlignment.Center;
                    G.DrawString(line2, courier, Brushes.Red, button1.ClientRectangle, SF);
                }
            }
            button.Image = bmp;
            button.ImageAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(button);
