        public void readDataGrid()
        {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
                 try
        {
        //Here read one by one cell and convert it into your required datatype and store it in 
         String rowcell1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
        }
        catch (Exception err)
        {
        }
        count++;
         }
        }
