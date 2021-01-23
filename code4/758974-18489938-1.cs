    using SomeNameSpaceWhereYouStoreExtensionMethods;
    try {
        // Some code that throws an exception
    }
    catch(Exception ex) {
    	Console.WriteLine(ex.ToMessageAndCompleteStacktrace());
    }
