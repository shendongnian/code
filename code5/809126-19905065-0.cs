     double sumP = 0;
        double sumF = 0;
       
            for (int i = 6; i < dataGridView1.Rows.Count-1; ++i)
            {
               
                
                    if (dataGridView1.Rows[i].Cells[6].Value.Equals("P"))
                    {
                                                                                               sumP += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                        }
                                  
                    else if (dataGridView1.Rows[i].Cells[6].Value.Equals("F"))
                    {
                        sumF += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                    }
    }
     If(sumF>sumP)
    {
    Label2.text="Fail";
    }
    else
    {
    label2.text="Pass";
     }
