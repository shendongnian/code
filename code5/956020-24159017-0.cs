    for(int i = 0; i< this.DB.Rows.Count-1; i++)
    {
        foreach (DataGridViewCell item2 in item.Cells)
        {   
            if(item2.Value != null)
                filewrite.Write(item2.Value.ToString() + " ");
        }
        
        filewrite.WriteLine("");
    }
