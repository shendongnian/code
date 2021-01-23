    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyInitializeComponent();
        }
        private void MyInitializeComponent()
        {
            // Add your desired properties here.
            this.combobox1.SelectedIndex = 0;
            // OR
            this.combobox1.SelectedValue = "1";
        }
    }
