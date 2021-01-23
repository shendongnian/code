    // Assume it is empty
    bool isRowEmpty = true;
    if (row == null)
    {
        isRowEmpty = true;
    }
    else
    {
        foreach(var columnValue in row.ItemArray)
        {
            if (columnValue != null)
            {
                isRowEmpty = false;
                break;
            }
        }
    }
