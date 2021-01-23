    foreach (string line in File.ReadAllLines(openBunkerDialog.FileName))
    {
        int index = line.IndexOf("crate(");
        if (index >= 0)
        {
            index += "crate(".Length;
            int endIndex = line.IndexOf(")", index);
            if (endIndex >= 0)
            {
                string inParentheses = line.Substring(index, endIndex - index);
                string[] all = inParentheses.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if(all.Length >= 3)
                {
                    float x, y, z;
                    float.TryParse(all[0].Trim(), out x);
                    float.TryParse(all[1].Trim(), out y);
                    float.TryParse(all[2].Trim(), out z);
                }
            }
        }
    }
