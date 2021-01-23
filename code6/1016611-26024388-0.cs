    public partial class Prices : Form
    {
        private Main _parent;
    
        public Prices(Main parent)
        {
            this._parent = parent;
            InitializeComponent();
    
        }
    
        private void save_Click(object sender, EventArgs e)
        {
            this._parent.Name = "HelloWorld";
        }
    }
