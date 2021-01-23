    str = "YOUR SQL QUERY";
    objCom = new SqlCommand(str, objCon);
    objDataAdapter = new SqlDataAdapter(objCom);
    objDataSet = new DataSet();
    objDataAdapter.Fill(objDataSet, "TABLE NAME");
    dataGridView2.DataMember = "TABLE NAME";
    dataGridView2.DataSource = objDataSet;
    dataGridView2[3, dataGridView2.Rows.Count - 1].Value = "Total";
    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Style.ForeColor =     Color.White;
    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Style.BackColor = Color.Green;
    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Style.ForeColor = Color.White;
    double sum = 0;
    for (int row = 0; row < dataGridView2.Rows.Count; row++)
    {
      sum = sum + Convert.ToDouble(dataGridView2.Rows[row].Cells[4].Value);
    } 
    dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Value = sum.ToString();
            
