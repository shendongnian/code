    int maxItems = 0;
    foreach (Control control in Controls)
    {
        if (control.GetType() == typeof(ListBox))
        {
            if (((ListBox)control).Items.Count > maxItems)
                maxItems = ((ListBox)control).Items.Count;
        }
    }
    for (int i = 0; i < maxItems; i++)
    {
        object lbxValue = lbxCount > i ? lbx.Items[i] : String.Empty;
        object ptrValue = ptrCount > i ? ptr.Items[i] : String.Empty;
        csvWriter.WriteField(lbxValue);
        csvWriter.WriteField(ptrValue);
        csvWriter.NextRecord();
    }
    sw.Flush();
