    public Version String2Version(string str)
                {
                    string[] parts = str.Split('.');
                    return new Version(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                }
    
    public ListBox fillComboBox(ListBox cb)
        {
            cb.Items.Clear();
            foreach(string[] s in SO)
            {
                if (s[1].Split(',')[1].Equals("G5IDD"))
                {
                    cb.Items.Add( String2Version(s[1].Split(',')[3]));
                }
            }
            cb.Sorted = true;
            return cb;
        }
