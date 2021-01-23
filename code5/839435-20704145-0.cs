    public class Form1 : Form
    {
        ...
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(dataGridView1);
            From2.Text = "some title text";
            form2.ShowDialog(this);
        }
    }
    public class Form2 : Form
    {
        private DataGridView form1DataGridView;
        public Form2(DataGridView form1DataGridView)
        {
            InitializeComponent();
            this.form1DataGridView = form1DataGridView;
            getData();
        }
        private void btn2_Click(object sender, EventArgs e)
        {
           // do something with form1DataGridView
        }
    }
