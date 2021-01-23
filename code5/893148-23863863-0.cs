    /*******************/
    /** Authorization **/
    /*******************/
    
    // Create a OAuth2 access/refresh token provider using your API key/secret.
    var tokenProvider = new TokenProvider("apiKey", "apiSecret");
    
    // Fetch the initial token pair using the OAuth2 authorization code...
    // You will want to persist these new values for later use.
    var initialTokenPair = tokenProvider.GetAccessToken("code");
    
    // You can also refresh the token pair.
    // You will want to persist these new values for later use.
    var newTokenPair = tokenProvider.RefreshAccessToken("refreshToken");
    
    /*********************/
    /** Box Interaction **/
    /*********************/
    
    // Instantiate a BoxManager client.
    var boxManager = new BoxManager(newTokenPair.AccessToken);
    
    // Create a new file in the root folder
    boxManager.CreateFile(Folder.Root, "a new file.txt", Encoding.UTF8.GetBytes("hello, world!"));
    
    // Fetch the root folder
    var folder = boxManager.GetFolder(Folder.Root);
    
    // Find a 'mini' representation of the created file among the root folder's contents
    var file = folder.Files.Single(f => f.Name.Equals("a new file.txt"));
    
    // Get the file with all properties populated.
    file = boxManager.Get(file);
    
    // Rename the file
    file = boxManager.Rename(file, "the new name.txt");
    
    // Create a new subfolder
    var subfolder = boxManager.CreateFolder(Folder.Root, "my subfolder");
    
    // Move the file to the subfolder
    file = boxManager.Move(file, subfolder);
    
    // Write some content to the file
    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("goodbye, world!")))
    {
        file = boxManager.Write(file, stream);
    }
    
    // Read the contents to a stream and write them to the console
    using (var stream = new MemoryStream())
    {
        boxManager.Read(file, stream);
        using (var reader = new StreamReader(stream))
        {
            stream.Position = 0;
            Console.Out.WriteLine("File content: '{0}'", reader.ReadToEnd());
        }
    }
    
    // Delete the folder and its contents
    boxManager.Delete(subfolder, recursive: true);
    
    As an enterprise administrator you can create a client and perform Box operations on behalf of another user.
    
    // Instantiate a BoxManager client.
    var boxManager = new BoxManager("AccessToken", onBehalfOf: "user@domain.com");
    
    // ... do stuff as that user
    // ... use your power only for awesome!
