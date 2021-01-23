    public partial class Form1 : Form
    {
        private ResxFile file;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            file = ResxFile.Load("XMLFile1.xml"); //open a openfiledialog here to get the actual filename
            
            var source = new BindingSource(file.DataNodes, null);
            
            dataGridView1.DataSource = source;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            file.Save("XMLFile1.xml"); //open a savefiledialog here to get the actual filename
        }
    }
