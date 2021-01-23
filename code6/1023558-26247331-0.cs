    // Note: can probably be better handled without using exceptions
    public class LoginFailedException : Exception
    {
        // ...
    }
    // Is this just a FileNotFound exception?
    public class FileNotAvailableException : Exception
    {
        // ...
    }
    public class FtpException : Exception
    {
        // ...
    }
