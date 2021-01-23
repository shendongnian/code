        private PictureBox pb;
        private void Truck_Load(object sender, EventArgs e)
        {
            pb = new PictureBox();
            pb.Location = new Point(10, 25);
            Image bg = Image.FromFile("fire2_clipped_rev_1.png");
            pb.BackgroundImage = bg;
            pb.Size = bg.Size;
            Bitmap img = new Bitmap(pb.Size.Width, pb.Size.Height);
            pb.Image = img;
            using (var g = Graphics.FromImage(img))
            {
                Truck.TruckF(pb.Location, g);
            }
            Controls.Add(pb);
        }
