    foreach (var l in line)
    {
        if (l.Contains(eventName))
        {
            string temp = l;
            int start = l.IndexOf(eventName);
            temp = temp.Remove(start, eventName.Length);
            temp = temp.Insert(start, newNameTextBox.Text.ToString());
            lines.Add(temp);
        }
        else
        {
            lines.Add(l);
        }
    }
