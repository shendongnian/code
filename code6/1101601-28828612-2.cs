    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox TextBox1 = (TextBox)GridView2.Rows[0].FindControl("TextBox1");
    
                    drCurrentRow["Zabeleshka"] = TextBox1.Text;
    
                  
