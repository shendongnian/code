    ThreadPool.QueueUserWorkItem(
                x =>
                    {
                        try
                        {
                            // Do something
                            ...
                        }
                        catch (Exception e)
                        {
                            // Log something
                            ...
                        }
                    });
