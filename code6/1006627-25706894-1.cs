        public Form1()
        {
            InitializeComponent();
            SizeChanged += Form1_SizeChanged;
        }
        void Form1_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            string myString = "Hello";
            Font stringFont = new Font("Arial", 20, FontStyle.Bold);
            Size textSize = TextRenderer.MeasureText(myString, stringFont);
            int formWidth = (int)(Size.Width - textSize.Width) / 2;
            int formHeight = (int)(Size.Height / 35);
            e.Graphics.DrawString(myString, stringFont, System.Drawing.Brushes.DarkBlue, formWidth, formHeight);
            e.Graphics.Flush();
        }
