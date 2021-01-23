    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void SetDataGrid( string[] data)
        {
            dataGridView1.Rows.Add(data);
        }
    }
