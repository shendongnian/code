    public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            Form2 f = new Form2(ds.Tables[0].Rows[e.RowIndex][0].ToString());
            f.Show();
        }
    }
    public partial class Form2 : Form
    {
        public Form2(string item)
        {
            InitializeComponent();
            listBox1.Items.Add(item);
        }
    }
