    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(comboBox1.Text, comboBox2.Text,  comboBox3.Text, textBox1.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["Form2"];
            if (f != null) //Make sure we have a form object 
            {
                ((Form2)f).SetDataGrid(new string[]{comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text});
            }
        }
    }
