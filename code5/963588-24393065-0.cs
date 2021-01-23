    private void cmdBot_Click(object sender, EventArgs e)
    {
        labels = new List<Label>();
    
        for (int i = 0; i <= dataGridView1.RowCount; i++)
        {
            Label gecoLabel = new Label();
            //**Since you're already looping through every row, why not just set the label text at the same time?
            gecoLabel.Text = dataGridView1.Rows[i].Cells["link"].FormattedValue.ToString();
            gecoLabel.AutoSize = true;
            gecoLabel.Location = new Point(100, 10 * i);
            groupBox1.Controls.Add(gecoLabel);
    
            labels.Add(gecoLabel);
        }
