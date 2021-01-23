    public partial class Form1 : Form
    {
        public bool floorOne; // global value (automatically set to false (default value of false)
        public Form1()
        {
            InitializeComponent();
        }
        public void button3_Click(object sender, EventArgs e)
        {
            bool floorOne = true; // new local value named floorOne (doesn change your global value)
            MessageBox.Show("value of global floorOne is: " + this.floorOne.ToString());
            // this.floorOne is your global value (try to find something about "this.")
            this.floorOne = true;
            MessageBox.Show("value of global floorOne is: " + this.floorOne.ToString());
        }
    }
