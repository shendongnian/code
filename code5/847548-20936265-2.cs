    public partial class Form1 : Form
    {
       private Database db = new Database();
       ...
    
       private void button1_Click(object sender, EventArgs e)
       {
          dataGridView1.DataSource = db.GetData();
          dataGridView1.DataMember = "invoice";
       }
    }
