    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        DataRow dr;      
                
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Lastname");
            dt.Columns.Add("PhoneNumber");
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            dr = dt.NewRow();
            dr["Firstname"] = textBox1.Text;
            dr["Lastname"] = textBox2.Text;
            dr["PhoneNumber"] = textBox3.Text;
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;     
        }
    }
