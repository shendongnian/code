<!-- -->
        // click handler
        private void ClickOnImage(object sender, EventArgs eventArgs)
        {
            var picBox = (PictureBox) sender;
            if (_gallery.Remove(picBox.Image))
                // if _gallery contained image, remove selection
                picBox.BorderStyle = BorderStyle.None;
            else
            {          
                // add selection
                picBox.BorderStyle = BorderStyle.Fixed3D;
                // add image to _gallery
                _gallery.Add(picBox.Image);
            }
        }
        // creates image with solid background
        private Bitmap GetImage(int p, Size s)
        {
            var bmp = new Bitmap(s.Width, s.Height);
            using (Graphics gr = Graphics.FromImage(bmp))            
                gr.Clear(Color.FromArgb(_rnd.Next(255), _rnd.Next(255), _rnd.Next(255)));            
            return bmp;
        }
    }
