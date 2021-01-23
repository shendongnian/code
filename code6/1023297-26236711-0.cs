    public ListBox fillComboBox(ListBox cb)
    {
        cb.Items.Clear();
        foreach(string[] s in SO.OrderBy(s => s.Split('.')[0]).ThenBy(s => s.Split('.')[1]))
        {
            if (s[1].Split(',')[1].Equals("G5IDD"))
            {
                cb.Items.Add(s[1].Split(',')[3]);
            }
        }
        cb.Sorted = true;
        return cb;
    }
