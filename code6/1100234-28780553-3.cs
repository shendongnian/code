    void close_exe(Process p, bool force = false)
        {
        if(force)
            {
            p.Kill();
            }
        else
            {
            p.CloseMainWindow();
            }
        }
