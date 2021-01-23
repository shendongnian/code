    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        DataTable table = new DataTable();
        BindingSource bind = new BindingSource();
    
        public Form1()
        {
          InitializeComponent();
          table.Columns.Add(new DataColumn("Name", typeof(string)));
          table.Columns.Add(new DataColumn("Value", typeof(Int32)));
          bind.DataSource = table;
          dataGridView1.DataSource = bind;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          table.Columns.Add(new DataColumn("Check", typeof(bool)));
        }
      }
    }
