    List<string> arrHeaders = new List<string>();
    for (int i = 0; i < short.MaxValue; i++)
    {
        string header = list.GetDetailsOf(null, i);
        if (String.IsNullOrEmpty(header))
            break;
        arrHeaders.Add(header);
    }
    
    foreach (Shell32.FolderItem2 item in list.Items())
    {
        for (int i = 0; i < arrHeaders.Count; i++)
        {
            //I used listbox to show the fields
            listBox1.Items.Add(string.Format("{0}\t{1}: {2}", i, arrHeaders[i], list.GetDetailsOf(item, i)));
        }
    }
 
