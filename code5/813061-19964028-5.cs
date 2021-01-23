    dataGridView1.RowsAdded += (s, e) => {
        for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++) {
            sum += ((double?)dataGridView1["sumColumn", i].Value).GetValueOrDefault();
        }
        textBox9.Text = sum.ToString();
    };
