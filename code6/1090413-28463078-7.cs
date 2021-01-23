        BindingList<AString> data = new BindingList<AString>();
        foreach (AStrings in list) data.Add(s);
        listBox1.DataSource = data;
        for (int i = data.Count - 1; i > 0; i--)
        {
            if (data[i].s.Contains("8"))
            {
                data.RemoveAt(i); // (list[i]);
            }
        }
