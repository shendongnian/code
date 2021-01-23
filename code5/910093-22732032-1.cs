    // Compare the two items
    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text,
                                          listviewY.SubItems[ColumnToSort].Text);
    if (listviewX.SubItems[ColumnToSort].Text=="") 
            compareResult = (OrderOfSort == SortOrder.Descending ? -1:  1);
    else if (listviewY.SubItems[ColumnToSort].Text=="") 
           compareResult = (OrderOfSort == SortOrder.Descending ? 1 : -1);
