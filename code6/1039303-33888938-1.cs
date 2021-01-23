<!-- -->
        public GalleryForm()
        {
            InitializeComponent();
            Name = "GalleryForm";
            Text = "Gallery";
            ClientSize = new Size(276, 274);
            // flowPanel will contain picture boxes with images
            flowPanel = new FlowLayoutPanel();
            flowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left| AnchorStyles.Right;
            flowPanel.Location = new Point(12, 12);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(252, 250);
            
            int picsCount = 4;
            var picSize = new Size(100, 100);
            var imSize = new Size(50, 50);
            // creates required number of picture boxes with simple images
            for (int p = 0; p < picsCount; p++)
            {
                var picBox = new PictureBox();
                picBox.Name = "pic" + (p+1).ToString();
                picBox.Size = picSize;
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                picBox.Image = GetImage(p, imSize);
                picBox.Click += ClickOnImage;
                flowPanel.Controls.Add(picBox);
            }
            Controls.Add(flowPanel);
        }
