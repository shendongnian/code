    public partial class Form1 : Form
    {
        private Class1 c = null;
    
        public Form1()
        {
            InitializeComponent();
    
            this.c = new Class1();
            this.c.Map.RegionClick += this.RegionMap_Clicked;
        }
    
        private void RegionMap_Clicked(int index, string key)
        {
            MessageBox.Show(key);
        }
    }
