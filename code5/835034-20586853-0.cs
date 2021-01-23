        private void Form1_Load(object sender, EventArgs e)
        {
            //stylise form
            this.BackColor = System.Drawing.Color.Black;
            PictureBox bgui = new PictureBox();
            bgui.Image = Properties.Resources.attack_box;
            bgui.Location = new System.Drawing.Point(100, 0);
            bgui.Name = "pictureBox1";
            bgui.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(bgui);
        }
