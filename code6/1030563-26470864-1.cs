    StreamReader reader;
    StreamWriter writer;
    string line, newText = null;
    using (reader = new StreamReader(@"..."))
    {
        while ((line = reader.ReadLine()) != null)
        {
            if (line != "checkbox name")
            {
                newText += line + "\r\n";
            }
        }
    }
    newText = newText.Remove(newText.Length - 2); //trim the last \r\n
    using (writer = new StreamWriter(@"...")) //same file
    {
        writer.Write(newText);
    }
