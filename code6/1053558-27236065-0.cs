    partial class Main : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            // Add whatever other initialization is needed here, of course
            new FormB(this).Show();
        }
    }
    partial class FormB : Form
    {
        private Main _main;
        public FormB(Main main)
        {
            _main = main;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Index of the row which is currently selected.
            int myIndex = dataGridView1.CurrentRow.Index;       
            DataGridViewRow row = this.dataGridView1.Rows[myIndex];
            brdok = row.Cells["Broj_dokumenta"].Value.ToString();
            _main.textRadniNalog.AppendText(brdok);
            _main.Focus();
            //close form B 
            this.Close();
        }
    }
