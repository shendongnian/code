    private void ProcessOutput()
    {
        string output;
        if (__OutputBuffer.TryDequeue(out output) && !String.IsNullOrEmpty(output))
        {
            try
            {
                Browser.DocumentText += "<span style='font-family: Tahoma; font-size: 9pt;'>" + output  + "</span>"; 
            }
            catch (Exception) { } // <--- Blindly catching exceptsions is almost never the right thing to do.
        }
    } 
