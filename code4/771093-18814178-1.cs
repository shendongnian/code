    public void exitApplication()
        {
            Process p;
            foreach (int p_id in chilProcess_id)
            {
                p = Process.GetProcessById(p_id);
                try
                {
                    if(!p.HasExited)
                        p.Kill();
                }
                catch (Exception e)
                {
                    //Handle the exception as you wish
                }
            }
        }
