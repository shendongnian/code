        PictureBox ChildBox;
        private void Form1_Load(object sender, EventArgs e) {
            ChildBox = new PictureBox();
            ChildBox.Visible = false;
            ChildBox.Location = new Point(0, 0); // change this to your coordinates, 480 by 380
            // the next 2 lines are just so that you can see the changes
            ChildBox.BackColor = Color.Red;
            pictureBox1.BackColor = Color.Blue;
            pictureBox1.Controls.Add(ChildBox);
        }
