    dataGridView1.Columns.Add(new DataGridViewColumn(new DataGridViewImageCell())); //Adding an image-type column
    dataGridView1.Rows.Add(); //Adding row 0
    
    OpenFileDialog od = new OpenFileDialog();
    od.ShowDialog();
    if (od.FileName != "")
    {
        label2.Text = od.FileName;
        dataGridView1[0, 0].Value = Image.FromFile(label2.Text);
    }
