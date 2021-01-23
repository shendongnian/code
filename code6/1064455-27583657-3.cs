    try
    {
            //Your code
    }
    catch(WebException e)
    {
            String status = ((FtpWebResponse)e.Response).StatusDescription;
    }
