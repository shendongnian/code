    private void button2_Click(object sender, EventArgs e)
    {
       List<string> items = new List<string>();
       foreach (DataGridViewRow item in dataGridView1.Rows)
       {
         if (null != item && null != item.Cells[0].Value)
         {
           items.Add(item.Cells[0].Value.ToString());
         }                
       }
    }
