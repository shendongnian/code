    public partial class Form2 : Form
    {
        //private ListBox.ObjectCollection objectCollection;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ListBox.ObjectCollection objectCollection)
        {
            InitializeComponent();
            
            //this.objectCollection = objectCollection;
            this.listBox1.DataSource =  objectCollection;
        }
    }
