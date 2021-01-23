    try
    {
        // Ensure that the user has consented to the wl.skydrive and wl.skydrive_update scopes.
        var authClient = new LiveAuthClient();
        var authResult = await authClient.LoginAsync(new string[] { "wl.skydrive", "wl.skydrive_update" });
        if (authResult.Session != null)
        {
            var liveConnectClient = new LiveConnectClient(authResult.Session);
 
            // Upload to OneDrive.
            LiveUploadOperation uploadOperation = await liveConnectClient.CreateBackgroundUploadAsync(
                uploadPath, fileName, uploadInputStream, OverwriteOption.Rename);
            LiveOperationResult uploadResult = await uploadOperation.StartAsync();
            HandleUploadResult(uploadResult);
        }
    }
    catch (LiveAuthException ex)
    {
        // Handle errors.
    }
    catch(LiveConnectException ex)
    {
        // Handle errors.
    }
