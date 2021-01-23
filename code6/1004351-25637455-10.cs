    public partial class Form2 : Form
    {
    
        public Form2()
        {
            InitializeComponent();
        }
    
        public Point GetLocation()
        {
            return new Point(Location.X, Location.Y);
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("location.x=" + Program.GlobalMainForm.Location.X + " location.y=" + Program.GlobalMainForm.Location.Y);
        }
    }
