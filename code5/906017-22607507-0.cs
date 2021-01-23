    public void WriteToCSV(string line, string path)
    {
        if (!string.IsNullOrEmpty(line))
        {
            string[] tmp = line.Split(',');
            if (tmp.Length > 3)
            {
                string smdrext = tmp[3];
    
                if (ext.Contains(Convert.ToString(smdrext)))
                {
                    File.AppendAllText(path, line + "\n");
                }
            }
        }
    
    }
