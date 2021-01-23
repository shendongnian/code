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
            if (tries == 5)
                throw;
        }
    }
