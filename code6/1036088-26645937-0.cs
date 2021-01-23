    string tempString = textBox1.Text;
    StringBuilder finalString = new StringBuilder();
    foreach (string word in tempString.Split(new char[] { ' ' })
    {
        foreach(string s in replacements.Keys)
        {
            finalString.Append(word.Replace(s, replacements[s]));
        }
    }
    textBox1.Text = finalString.ToString();
