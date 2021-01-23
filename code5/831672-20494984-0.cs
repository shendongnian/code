    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ParentChanged += MyParentChanged;
        }
        public void MyParentChanged(Object sender, EventArgs e)
        {
            this.Parent = null;
        }
    }
