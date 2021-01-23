    c#:
    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
    foreach(DataRow dr in csrst2.Tables[0].Rows)
    {
        var findfirst = csrst1.Tables[0].Select("[L1]=" + dr[0] + "  AND [D1]=#" + dr[1] + "#");
        if(findfirst.Count() < 1)
        {
            var newRow = csrst1.Tables[0].NewRow();
            //...new row fields set
            csrst1.Tables[0].Rows.Add(newRow);
            adapter.Update(csrst1.Tables[0]);
        }
        else
        {   
            findfirst[0].BeginEdit();
            //...rows edited
            findfirst[0].AcceptChanges();
            adapter.Update(csrst1.Tables[0]);
        }
    }
