    private void Module_Watchdog(object obj)
    {
       try
       {
       throw new TimeoutException();
       }
       finally
       {
         // Whatever you would like to do with the timeout.
       }
    }
