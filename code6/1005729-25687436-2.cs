    string persistentDbLocation = @"C:\Users\Gord\Desktop\resTestUserData.accdb";
    if (File.Exists(persistentDbLocation))
    {
        Console.WriteLine("Local persistent copy of database already exists.");
    }
    else
    {
        // "resTest" is the name I gave to my C# Project, hence resTest.Properties
        byte[] dbResource = resTest.Properties.Resources.resTestData;  // .accdb File Resource
        using (FileStream output = new FileStream(persistentDbLocation, FileMode.Create, FileAccess.Write))
        {
            output.Write(dbResource, 0, dbResource.Length);
        }
        Console.WriteLine("Local persistent copy of database saved to \"{0}\".", persistentDbLocation);
    }
