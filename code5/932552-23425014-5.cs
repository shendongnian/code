    public partial class Form2 : Form
    {    
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ListBox.ObjectCollection objectCollection)
        {
            InitializeComponent();           
           
            this.listBox1.DataSource =  objectCollection;
        }
    }
