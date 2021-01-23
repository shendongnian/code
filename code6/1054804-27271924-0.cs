    void setSort()
    {
        string id = dataGridView1[0, 0].Value.ToString();
        int sOrder = 0;
        for (int row = 0; row < dataGridView1.Rows.Count; row++)
        {
            if (dataGridView1[0, row].Value == null) break;
            string id2 = dataGridView1[0, row].Value.ToString();
            if (id2 != id) sOrder = 0;
            sOrder++;
            dataGridView1[1, row].Value = sOrder;
            id = id2;
        }
    }
