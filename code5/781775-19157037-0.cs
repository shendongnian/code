     Point _imagePos = new Point(10,10);
        int _imageCounter = 1;
        private void NewPictureBox(string pathToImg, string imageName)
        {
            var img = new PictureBox 
                { 
                    Name = "imageBox" + _imageCounter, 
                    ImageLocation = pathToImg, 
                    Left = _imagePos.X, 
                    Top = _imagePos.Y,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Height = 50,
                    Width = 50
                };
            var txt = new TextBox
                {
                    Text = imageName,
                    Left = _imagePos.X,
                    Top = img.Bottom + 10
                };
            this.Controls.Add(img);
            this.Controls.Add(txt);
            _imageCounter++;
            _imagePos.Y += 10 + img.Height + txt.Height;           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NewPictureBox(@"C:\test\QuestionMark.jpg", "image1");
            NewPictureBox(@"C:\test\QuestionMark.jpg", "image2");
        }
