    // Assume it is empty
    bool isRowEmpty = true;
    if (row != null)
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
