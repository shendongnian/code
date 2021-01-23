    private void Button1_Click(object sender, EventArgs e)
        {
            // create Form instance
            Form form = new Form
            {
                Text = "About Us",
                Width = 440,
                Height = 460,
            };
            // create bmp image
            Bitmap bmp = new Bitmap(400, 400);
            // draw on bmp image
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.Transparent);
                Rectangle rectangle = new Rectangle(100, 100, 200, 200);
                graphics.DrawEllipse(Pens.Black, rectangle);
                graphics.DrawRectangle(Pens.Red, rectangle);
            }
            // create PictureBox instance
            PictureBox pictureBox = new PictureBox
            {
                Image = bmp,
                //BorderStyle = BorderStyle.FixedSingle,
                //Dock = DockStyle.Fill,
                /// To center
                Size = new Size(400,400),
                Location = new Point(10,10)
            };
            // add pictureBox control to form
            form.Controls.Add(pictureBox);
            // show form in dialog box
            form.ShowDialog();
        }
