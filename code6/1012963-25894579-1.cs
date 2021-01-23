        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string columnName = "filename";
            bool partial = false;  // full comparison or only a substring is searched
            bool includeExtensions = true;  // include the file extension in the search
            bool ignoreCase = true;   // make the search case-(in)sensitive
            string search = textBox1.Text;
            if (ignoreCase) search = search.ToLowerInvariant();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string v = dataGridView1.Rows[i].Cells[columnName].Value.ToString();
                if (ignoreCase) v = v.ToLowerInvariant();
                string f = includeExtensions ? 
                            Path.GetFileName(v) : Path.GetFileNameWithoutExtension(v);
                if (partial) dataGridView1.Rows[i].Selected = (f.IndexOf(search) >= 0);
                else dataGridView1.Rows[i].Selected = (f == search);
            }
            label1.Text = dataGridView1.SelectedRows.Count.ToString() + " files found.";       
        }
