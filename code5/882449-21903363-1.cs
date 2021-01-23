        private void PrintPreview(object sender, EventArgs e)
        {
            ...
            this.dataGridView1.Columns["ID"].Visible = false;
            _PrintPreview.ShowDialog();
            this.dataGridView1.Columns["ID"].Visible = true; // restore visibility
        }
