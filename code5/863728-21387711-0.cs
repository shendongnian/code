    protected void SizeColumns(object sender, DataGridColumnCollection dgCol)
    {
        if(dgCol.Count > 0)
        {
            for(int i = 0; i < dgCol.Count; i++)
            {
                dgCol[i].ItemStyle.Width = *Whatever you wish*;
            }
        }
    }
