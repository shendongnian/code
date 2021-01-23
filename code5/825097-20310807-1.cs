    using (StreamReader sr = File.OpenText(path)) // you can remove this line
    {
        string[] lines = File.ReadAllLines(path); // as you are not using it here
        for (int x = 0; x < lines.Length - 1; x++)
        {
            if (domain == lines[x])
            {
                sr.Close();
                MessageBox.Show("there is a match");
                hasMatch = true;
                break; // exit loop if found
            }
        }
    
        if (!hasMatch)
        {
            // there is no match
        }
    
        if (sr != null) // you dont need this if you remove it from the beginning of the code
        {
            sr.Close();
            MessageBox.Show("there is no match");
        }
    }
