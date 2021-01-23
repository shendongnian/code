    finally
    {
        while(!inkScape.HasExited)
        {
            inkscape.WaitForExit(500);
            Application.DoEvents();
        }
    }
