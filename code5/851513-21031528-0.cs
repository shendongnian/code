        private List<PictureBox> pictures = null;
        string[] ImageNames = new string[]
                {
                    "images\\test_1.jpg",
                    "images\\test_2.jpg"
                };
        private void Form1_Load(object sender, EventArgs e)
        {
            pictures = new List<PictureBox>();
            for (var idx = 0; idx < ImageNames.Length; idx++)
            {
                pictures.Add(new PictureBox());
                pictures[idx].Image = new Bitmap(ImageNames[idx]);
                pictures[idx].Click += OnClick;
                // you'll want to set the offset and everything so it shows at the right place
                Controls.Add(pictures[idx]);
            }
        }
        private void OnClick(object sender, EventArgs eventArgs)
        {
            // you'll definitely want error handling here
            var ImageName = ImageNames[pictures.IndexOf((PictureBox) sender)];
        }
