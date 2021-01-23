    string CatID = string.Empty;
    int i = ListBox1.Items.Count(); //not sure with this
    string[] CatValues = new string[i];
    int iCount = 0;
    foreach (ListItem li in ListBox1.Items)
    {
        if (li.Selected == true)
        {
            // get the value of the item in your loop
            CatID += li.Value + ",";
            CatValues[iCount] = li.Value;
            iCount++;
        }
    }
