    public partial class Form1 : Form
    {
        private ResxFile file;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            file = ResxFile.Load("XMLFile1.xml");
            var bindingList = new BindingList<IResxFileDataNode>(file.DataNodes);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            file.Save("XMLFile1.xml");
        }
    }
