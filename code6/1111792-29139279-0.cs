    logger.LogAsync(...).ContinueWith(x => {
        if (x.IsFaulted)
        {
            // you need to touch x.Exception property here
            // or your application will crash because of unhandled exception
            Console.WriteLine("LogAsync error occured: {0}", x.Exception);
        }
        logger.Dispose();
    });
    
