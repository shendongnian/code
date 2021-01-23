    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.Rows.Add(new[] { "L00000422", "", "","A" });
        dataGridView1.Rows.Add(new[] { "Enter Amount", "", "","" });
        dataGridView1.Rows.Add(new[] { "", "", "","" });
        dataGridView1.Rows.Add(new[] { "L00000423", "", "" ,"B"});
        dataGridView1.Rows.Add(new[] { "Enter Amount", "", "", "" });
        dataGridView1.Rows.Add(new[] { "", "", "", "" });
        foreach (var row in dataGridView1.Rows)
        {
            var r = (DataGridViewRow) row;
            foreach (var col in dataGridView1.Columns)
            {
                var cl = (DataGridViewColumn) col;
                if (cl.Index == 3)
                {
                    var cc = (DataGridViewComboBoxCell)dataGridView1[3,r.Index];
                    if (r.Index % 3 != 0)
                    {
                        cc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        cc.ReadOnly = true;
                    }
                    else
                    {
                        cc.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                        cc.ReadOnly = false;
                    }
                }
            }
        }
    }
