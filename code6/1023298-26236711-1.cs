    public ListBox fillComboBox(ListBox cb)
    {
        cb.Items.Clear();
        foreach(string[] s in SO.ToArray().OrderBy(s => s.ToString().Split('.')[0]).ThenBy(s => Int32.Parse(s.ToString().Split('.')[1])))
        {
            if (s[1].Split(',')[1].Equals("G5IDD"))
            {
                cb.Items.Add(s[1].Split(',')[3]);
            }
        }
        cb.Sorted = true;
        return cb;
    }
