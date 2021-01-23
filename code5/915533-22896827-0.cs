    namespace test
    {
        public partial class SelectSize : Form
        {
            public SelectSize(String name)
            {
      
                InitializeComponent();
                this.Name = name;
            }
    
            public String Name
            { get; set; }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(this.Name); // It must show a string from SelectSize's constructor
            }
    
        }
    }
