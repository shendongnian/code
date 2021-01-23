    var sw = new StreamWriter(@"output.csv");
    var csvWriter = new CsvHelper.CsvWriter(sw);
    int maxRecords = 0;
    List<ListBox> listBoxes = new List<ListBox>();
    // Add all ListBox controls to list
    // Determine maximum number of items (in all ListBox controls)
    foreach (Control control in Controls)
    {
        if (control.GetType() == typeof(ListBox))
        {
            ListBox currentListBox = (ListBox)control;
            listBoxes.Add(currentListBox);
            if (currentListBox.Items.Count > maxRecords)
                maxRecords = currentListBox.Items.Count;
        }
    }
    // Write fields for each ListBox
    for (int i = 0; i < maxRecords; i++)
    {
        foreach (ListBox currentListBox in listBoxes)
        {
            if (currentListBox.Items.Count > i)
                csvWriter.WriteField(currentListBox.Items[i]);
            else
                csvWriter.WriteField(String.Empty);
        }
        csvWriter.NextRecord();
    }
    sw.Flush();
    sw.Close();
