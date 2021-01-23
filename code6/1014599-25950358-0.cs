     private List<Label> _labels;
        public Form1()
        {
            InitializeComponent();
            _labels = new List<Label>();
            for (var i = 0; i <= 20; i++)
                _labels.Add(new Label()
                {
                    Name = "lbl" + i, Height = 50,Width = 200,
                    Size = MinimumSize = new Size(200, 50),
                    Location = new Point(i * 200 % 600, 50 * (i * 200 / 600)),
                    BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                    Text = "Label " + i
                });
            foreach (var lbl in _labels) this.Controls.Add(lbl);
        }
