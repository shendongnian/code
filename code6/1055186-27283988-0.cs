    int rowsCount = GridView1.Rows.Count;
    int rowsInserted = 0;
    for (int i = 0; i < rowsCount; i++)
    {
        StrQuery = @"INSERT INTO OrderDetail (OrderNumber, PartNumber, Qty, Price, ExtPrice) VALUES   (@OrderNumber, @PartNumber,@Qty,@Price,@ExtPrice)";
        scm.CommandText = StrQuery;
        scm.Parameters.AddWithValue("@OrderNumber",GridView1.Rows[i].
                          Cells["columnName"].Value);
        scm.Parameters.AddWithValue("@PartNumber",GridView1.Rows[i].
                          Cells["columnName"].Value);
        scm.Parameters.AddWithValue("@Qty",GridView1.Rows[i].
                          Cells["columnName"].Value);
        scm.Parameters.AddWithValue("@Price",GridView1.Rows[i].
                          Cells["columnName"].Value);
        scm.Parameters.AddWithValue("@ExtPrice",GridView1.Rows[i].
                          Cells["columnName"].Value);
    if (scm.ExecuteNonQuery() > 0)
    {
        rowsInserted++;
    }
    scm.Parameters.Clear();
    }
    //check if all rows inserted
    if(rowsCount == rowsInserted)
    {
       //Display successfull message
    }
    else
    {
      //Display error message
    }
