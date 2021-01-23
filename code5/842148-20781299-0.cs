    private void Form1_Load(object sender, EventArgs e)
            {
                byte[] offset = { 0, 2, 6, 8, 10, 14, 18, 22, 26 };
                byte[] sizebyte = { 4, 2, 2, 4, 4, 4, 4, 2 };
                string[] description = { "signature", "size BMP", "reserved", "reserved", "offset start image", "must 40", "width", "height" };
    
                this.dataGridView1.Columns.Add("offset", "offset");
                this.dataGridView1.Columns.Add("sizebyte", "sizebyte");
                this.dataGridView1.Columns.Add("description", "description");
                int i = offset.Length;
               
                   
                    for (int j = 0; j < i; j++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);
                        row.Cells[0].Value = offset.GetValue(j).ToString();
                        if(j<sizebyte.Length)
                        row.Cells[1].Value = sizebyte.GetValue(j).ToString();
                        if (j < description.Count())
                        row.Cells[2].Value = description.GetValue(j).ToString();
                        dataGridView1.Rows.Add(row);
                    }
                   
                   
                  
            }
