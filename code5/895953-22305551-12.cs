    void Run(int n, bool doThrow, bool doExcept)
    {
        for (int i = 0; i < n; i++)
        {
            if (doExcept)
            {
                try
                {
                    if (doThrow)
                        throw new NotImplementedException();
                }
                catch (NotImplementedException)
                {
                }
            }
        }
    }
