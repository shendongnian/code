    using (StreamReader sr = File.OpenText(path))
    {
        string[] lines = File.ReadAllLines(path);
        bool isMatch = false;
        for (int x = 0; x < lines.Length - 1; x++)
        {
            if (domain == lines[x])
            {
                sr.Close();
                MessageBox.Show("there is a match");
                isMatch = true;
            }
        }
        if (!isMatch)
        {
            sr.Close();
            MessageBox.Show("there is no match");
        }
    }
