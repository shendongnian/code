    public partial class notesForm : DockContent
    {
        // On runtime this will in fact the `parentForm` object instance.
        IDataContainer myDataContainerInstance = null;
        public notesForm(IDataContainer myDataContainerInstance)
        {
            InitializeComponent();
            // Assign the reference so that you can use it later
            this.myDataContainerInstance = myDataContainerInstance;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.myDataContainerInstance.SetData(textBox1.Text);
        }
    }
