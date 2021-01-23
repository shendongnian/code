     public void Method(){
         for (int i = 1; i < dataGridView2.Rows.Count; i++)
            {
                string partnumber = dataGridView2.Rows[i - 1].Cells["PART NUMBER"].Value.ToString();
                double onhand = double.Parse(dataGridView2.Rows[i - 1].Cells["TOTAL-ON-HAND"].Value.ToString());
                for (int j = 1; j < dataGridView1.Rows.Count; j++)
                {                   
                    string part = dataGridView1.Rows[j - 1].Cells["Part #"].Value.ToString();
                    double BL = double.Parse( dataGridView1.Rows[j - 1].Cells["BL"].Value.ToString());
                    if(partnumber ==  part)
                    {
                        if (onhand >= BL)
                        {
                            onhand = onhand - BL;
                            MessageBox.Show(partnumber.ToString() +": " + onhand.ToString());
                        }
                        else { break; }
                    }
                }
              }
