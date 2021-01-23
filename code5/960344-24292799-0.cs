        while (retry <= retryCount)
        {
            try
            {
                message = null;
                //get response
            }
            catch (InvalidOperationException invalid)
            {
                message = invalid.Message; //display status message 
            }
            catch (Exception exc)
            {
                //display log message 
                //retry again 
                message = exc.Message; //display status message 
                retry++;
            }
            if (!string.IsNullOrEmpty(message))
            {
                message = "Mamium tries have been exceeded"
                Logs.WriteError(message);
                return false;
            }
        }
