    int tries = 0;
    bool completed = false;
    while (!completed)
    {
        try
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            file.Write(text);
            file.Close();
            completed = true;
        }
        catch(Exception exc)
        {
            tries++;
            //You could possibly put a thread sleep here
            if (tries == 5)
                throw;
        }
    }
