    try
    {
        // some code here ...
        
        FileAccessHelper.WaitForFileAccessibility("Test.dat", 1000);
        
        // and here ...
    }
    catch (FileAccessHelperException e)
    {
        // your error handling here...
        Console.WriteLine("Unable to open the file within 1000ms");
    }
