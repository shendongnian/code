    public Form1()
        {
            InitializeComponent();
            
            panel2.SizeChanged +=panel2_SizeChanged;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Size = new Size(panel2.Size.Width * 2, panel2.Size.Height * 2);
        }
        void panel2_SizeChanged(object sender, EventArgs e)
        {
            panel1.Size = panel2.Size;
        }
