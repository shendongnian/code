    List<JournalEntry> journalEntryList = new List<JournalEntry>();
    JournalEntry je;
    foreach (string line in file.Lines)
    {
        string[] mls = line.Split(','); // mls is short for MyLineSplit
        string[] dateinfo = mls[2].Split('/');
        je = new JournalEntry(mls[0], mls[1], Convert.ToInt32(dateinfo[0]), Convert.ToInt32(dateinfo[1]), Convert.ToInt32(dateinfo[2]), mls[3]);
        journalEntryList.Items.Add(je);
    }
