    StreamReader reader;
    StreamWriter writer;
    string line, line_ = null;
    using (reader = new StreamReader(@"..."))
    {
        while ((line = reader.ReadLine()) != null)
        {
            if (line != "checkbox name")
            {
                line_ += line + "\r\n";
            }
        }
    }
    line_ = line_.Remove(line_.Length - 2); //trim the last \r\n
    using (writer = new StreamWriter(@"...")) //same file
    {
        writer.Write(line_);
    }
