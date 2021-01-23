        string[] lines = null;
        try
        {
            lines = File.ReadAllLines(path);
        }
        catch(Exception ex)
        {
            // inform user or log depending on your usage scenario
        }
        if(lines != null)
        {
            // do something with lines
        }
