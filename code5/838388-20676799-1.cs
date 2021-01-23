    public partial class Form1 : Form
    {
        Class1 c = null;
    
        public Form1()
        {
            InitializeComponent();
    
            c = new Class1(this);
        }
    
        public void RegionMap_Clicked(int index, string key)
        {
            MessageBox.Show(key);
        }
    }
