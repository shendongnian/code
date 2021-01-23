        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var pictureBoxes = Controls.OfType<PictureBox>().ToArray();
            if (pictureBoxes.Length > 1)
            {
                for (int i = 1; i < pictureBoxes.Length; i++)
                {
                    DrawLineBetween(e.Graphics, pictureBoxes[i - 1], pictureBoxes[i]);
                }
            }
        }
