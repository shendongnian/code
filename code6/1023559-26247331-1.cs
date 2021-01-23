    try
    {
        // ...
    }
    catch (LoginFailedException)
    {
        Debug.WriteLine("wrong username/password");
        MainController.Status = "2";
    }
    catch (FileNotAvailableException)
    {
        Debug.WriteLine("File is not Available");
        MainController.Status = "3";
    }
    catch (FtpException)
    {
        Debug.WriteLine("General FTP Error");
        MainController.Status = "4";
    }
