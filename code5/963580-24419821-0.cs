        private void button1_Click(object sender, EventArgs e)
        {
            using (SecondForm form = new SecondForm())
            {
                form.titRicerca = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString().ToUpper();
                form.datRicerca = dataGridView1.CurrentRow.Cells["Column4"].Value.ToString().ToUpper();
                form.ShowDialog();
                // after you have exited the second form, form.titRicerca and form.datRicerca will
                // still be available for as long as you are in this using clause.  Assign them
                // elsewhere if you need the parent form to access them
            }
        }
