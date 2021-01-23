        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(filePath);
        string[] line = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        List<string> lines = new List<string>();
        string eventName = ','+eventNameUpdateTextBox.Text.ToString()+',';
        foreach (var l in line)
        {
            if (l.Contains(eventName))
            {
                int start = l.IndexOf(eventName);
                l = l.Remove(start, eventName.Length);
                l = l.Insert(start, newNameTextBox.Text.ToString());
                lines.Add(l);
            }
            else
            {
                lines.Add(l);
            }   
        }
        string toCsvOutput = string.Join(Environment.NewLine, lines.ToArray());
