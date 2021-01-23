        public Form1()
        {
            InitializeComponent();
            this.MouseUp += new MouseEventHandler(Form1_MouseUp);
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("X: " + Cursor.Position.X + " - Y: " + Cursor.Position.Y);
            var goodCoordinates = PointToClient(Cursor.Position);
            Console.WriteLine("X: " + goodCoordinates.X + " - Y: " + goodCoordinates.Y);
        }
