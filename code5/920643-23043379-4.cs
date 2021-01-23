        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                pad.Location = new Point(pad.Location.X - 1, pad.Location.Y);
                return true; 
            }
            else if (keyData == Keys.Right)
            {
                pad.Location = new Point(pad.Location.X + 1, pad.Location.Y);
                return true; 
            }
            else if (keyData == Keys.Up)
            {
                return true; 
            }
            else if (keyData == Keys.Down)
            {
                return true; 
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
