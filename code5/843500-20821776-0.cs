    public void FillDataGridView()
    {
        //images
        var greenImg = Resources.green;
        var redImg = Resources.red;
        var yellowImg = Resources.yellow;
        
        dataGridView1.Rows.Add(new object[] {"Vland", greenImg});
        dataGridView1.Rows.Add(new object[] {"John", yellowImg });
        dataGridView1.Rows.Add(new object[] {"Paul", greenImg});
        dataGridView1.Rows.Add(new object[] {"George", redImg});
        dataGridView1.Rows.Add(new object[] {"Ringo", redImg });
    }
