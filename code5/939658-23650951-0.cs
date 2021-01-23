    while ((line = file.ReadLine()) != null)
    {
        line = line.Trim();
        if(line.Equals(lineDelete, StringComparison.CurrentCultureIgnoreCase));
            continue;
        else
            writer.WriteLine(line);
    }
