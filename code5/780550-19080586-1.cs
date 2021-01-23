    string display = "";
    // Every item in this collection is an item 
    // with CheckState = Checked or Indeterminate
    if (clb.CheckedItems.Count != 0)
    {
        StringBuilder sb = new StringBuilder();
        foreach(string item in clb.CheckedItems)
            sb.AppendLine(item);
        display = "Items needed\n-----------\n\n\n" + sb.ToString();
    }
    else
    {
        display = "No items checked";
    }  
    MessageBox.Show(display, "Title");
