    foreach (DataGridViewRow item in this.DB.Rows)
    {
        var printRow = false;
        foreach (DataGridViewCell item2 in item.Cells)
        {   
            if(!String.IsNullOrWhitespace(item2.Value.ToString()))
            {
                printRow = true;
                filewrite.Write(item2.Value.ToString() + " ");
            }
        }
        if (printRow)
        {
            filewrite.WriteLine("");
        }
    }
