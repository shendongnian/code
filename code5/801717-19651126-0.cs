    public partial class MyForm : Form
    {
        private MyData dataIn;
        // Option 1: property that can be read from another class
        public MyData result { get; private set; }
        // Option 2: method you can call to get the result object
        public MyData GetResult()
        {
            return result;
        }
        public MyForm(MyData data)
        {
            InitializeComponent();
            dataIn = data;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // set result object
            result = new MyData { v1 = "some string value", v2 = 123 }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
