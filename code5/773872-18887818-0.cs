    private List<Tuple<Image, int, int>> images = new List<Tuple<Image, int, int>>();
    private void Form1_Load(object sender, EventArgs e)
    {
        //load the customer image
        this.picBoxTarget.BackgroundImage = Image.FromFile(...);
        //load the necklaces image
            this.picBoxSource.Image = Image.FromFile(...);
        }
        private void picBoxSource_Click(object sender, EventArgs e)
        {
            if (this.picBoxSource.Image == null)
                return;
            //when click the picBoxSource, add the image to list
            //(you may need to check whether there is another one necklace in the list, if not allowed to wear two)
            this.images.Add(Tuple.Create(this.picBoxSource.Image, 480, 380));
            //and make the picBoxTarget redraw
            this.picBoxTarget.Invalidate();
        }
        private void picBoxTarget_Paint(object sender, PaintEventArgs e)
        {
            foreach (var img in this.images)
                e.Graphics.DrawImage(img.Item1, img.Item2, img.Item3);
        }
