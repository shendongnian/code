    public partial class Form1 : Form
    {
       ...
    
       private void button1_Click(object sender, EventArgs e)
       {
          Database db = new Database();
          dataGridView1.DataSource = db.GetData();
          dataGridView1.DataMember = "invoice";
       }
    }
