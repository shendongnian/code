    public partial class MineSweeper : UserControl
    {
        public MineSweeper()
        {
            InitializeComponent();
        }
    
        private void MineSweeper_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            for (int i = 0; i < 16; i++)
            {
                var button = new Button();
                button.Name = "Button" + i;
                button.Size = new Size(50, 50);
                button.ForeColor = Color.Yellow;
                button.ForeColor = Color.Black;
                button.Click += delegate
                {
                    MessageBox.Show("You have clicked me! I am " + button.Name);
                };
                flowLayoutPanel1.Controls.Add(button);
                flowLayoutPanel1.Invalidate();
            }
    
            this.Invalidate();
        }
    }
