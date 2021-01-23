    // dataGridView2.ColumnCount = 4;  
    int w = 0;
    foreach (var item in tInArr)
    {...
      w = dataGridView2.Rows.Add();
      dataGridView2[0, w].Value = muTat3.ToString();
      dataGridView2[1, w].Value = item.ToString();
      ....
      //w++; this is not required
    }
