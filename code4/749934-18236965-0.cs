    private static bool ExitInternal()
    {
        bool flag = false;
        lock (internalSyncObject)
        {
            if (exiting)
            {
                return false;
            }
            exiting = true;
            try
            {
                if (forms != null)
                {
                    foreach (Form form in OpenFormsInternal)
                    {
                        if (form.RaiseFormClosingOnAppExit())
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    if (forms != null)
                    {
                        while (OpenFormsInternal.Count > 0)
                        {
                            OpenFormsInternal[0].RaiseFormClosedOnAppExit();
                        }
                    }
                    ThreadContext.ExitApplication();
                }
                return flag;
            }
            finally
            {
                exiting = false;
            }
        }
        return flag;
    }
