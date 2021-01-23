    try
    {
        using (StreamWriter sw = new StreamWriter(@"Path.txt", true))
        {
            sw.WriteLine(write);
        }
    }
    catch (Exception ex)
    {
        // Exception handling here...
    }
