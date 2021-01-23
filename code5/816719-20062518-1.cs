            try
            {
                   //Run Code here
            }
            catch (ArgumentNullException ane)
            {
                 // ignore exception here
            }
            catch (AggregateException ae)
            {
                 //ignore exception here
            }
            catch (Exception genericException)
            { 
              // this must be last to catch unhandled exceptions
            }
