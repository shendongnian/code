    partial class FormB : Form
    {
        private Main _main;
        public FormB(Main main)
        {
            _main = main;
            if (_main != null)
            {
                _main.FormClosed += (sender, e) => _main = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_main != null)
            {
                //Index of the row which is currently selected.
                int myIndex = dataGridView1.CurrentRow.Index;       
                DataGridViewRow row = this.dataGridView1.Rows[myIndex];
                brdok = row.Cells["Broj_dokumenta"].Value.ToString();
                _main.textRadniNalog.AppendText(brdok);
                _main.Focus();
            }
            else
            {
                new Main().Show();
            }
            //close form B 
            this.Close();
        }
    }
