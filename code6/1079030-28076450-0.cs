        finally
        {            
            if (process != null)
            {
                try
                {
                    if (!process.HasExited)
                    {                            
                        Utilities.KillProcessTree(process);
                    }
                }
                catch (InvalidOperationException e)
                {
                    // Trace
                }
                catch (ExternalException e)
                {
                    // Trace
                }
                finally
                {
                    process.Dispose();
                }
            }                
            if(processGroupLimitJobMemory != null)
            {                    
                processGroupLimitJobMemory.Dispose();
            }
      }
