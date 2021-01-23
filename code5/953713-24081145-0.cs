        public void draw(int[] array)
        {
            Bitmap afbeelding = new Bitmap(11, 11);
            
            for (int i = 0; i < array.Length; i++)
            {
                afbeelding.SetPixel(array[i], array[i], Color.Black);
            }
            pictureBox1.Image = afbeelding;
            //afbeelding = pictureBox1.CreateGraphics();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            draw(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }
