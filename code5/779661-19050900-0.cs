    var tableOneIndex = -1;
    var tableTwoIndex = -1;
    
    foreach (var tableOneRow in tableOne.Rows)
    {
        tableOneIndex++;
        foreach (var tableTwoRow in tableTwo.Rows)
        {
            tableTwoIndex++;
            
            if (tableOneRow["name"].ToString() == tableTwoRow["name"].ToString())
            {
                 // Do whatever you wanted to do with the index values
            }
        }
    }
