        public Form1()
        {
            InitializeComponent();
        }
            string x,y;
            int x1, y1;
            x=textBox1.Text;
            y=textBox2.Text;
            x1 = Convert.ToInt16(x);
            y1 = Convert.ToInt16(y);
            int[,] daten = new int[x1, y1];
