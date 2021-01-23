    private void x(string str)
    {
        while (this.Application.Interactive == true)
        {
            // If Excel is currently busy, try until go thru
            SetAppInactive();
        }
    
        // now writing the data is protected from any user interaption
        try
        {
            for (int i = 1; i < 2000; i++)
            {
                sh.Cells[i, 1].Value2 = str;
            }
        }
        finally
        {
            // don't forget to turn it on again
            this.Application.Interactive = true;
        }
    }
    private void SetAppInactive()
    {
        try
        {
            this.Application.Interactive = false;
        }
        catch
        {
        }
    }
