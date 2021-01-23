        private void createPicBoxes()
        {
            for (int i = 0; i <= 12; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Click += picBox_Click;
            }
        }
        static void picBox_Click(object sender, EventArgs e)
        {
            //do your stuff here which handles generically all of your picture boxes clicks.
        }
