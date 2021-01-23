    DataTable table = new DataTable();
    table = GetTable();
    string expression;
    expression = "B.Id = " + textBox1.Text;
    DataRow[] foundRows;
    foundRows = table.Select(expression);
    for (int i = 0; i < foundRows.Length; i++)
    {
    sno.Text = foundRows[i][1].ToString();
    name.Text = foundRows[i][2].ToString();
    dcn.Text = foundRows[i][3].ToString();
    stat.Text = foundRows[i][4].ToString();
    }
    DataTable table = new DataTable();
        table = GetTable();
        string expression;
        expression = "B.Id = "+textBox1.Text;
        DataRow[] foundRows;
        foundRows = table.Select(expression);
        for(int i = 0; i < foundRows.Length; i ++)
        {
         if(button1.Text == "Make Preasent!")
         {
             foundRows[i][4] = true;
            table.AcceptChanges();
         }
         else
         {
             foundRows[i].SetField(4, false);
             table.AcceptChanges();
         }
        }
