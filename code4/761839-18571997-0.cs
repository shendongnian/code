    var myLogger = new MyLogger();
    try
    {      
        // here is your app which calls myLogger.WriteLine(...) often
    }
    catch(Exception ex)
    {
        // log it
    }
    finally
    {
        myLogger.Dispose(); // myLogger is your Log class, dispose should call myStream.Dispose();
    }
