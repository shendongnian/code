    ...
    var readAttempt = await xmlStorage.TryReadObjectAsync<UserProfile>(userName, UserProfileFilename);
    if (readAttempt.HasResult)
    {
        // Continue.
        this.DoSomethingWith(readAttempt.Result);
    }
    else
    {
        // Create new user.
    }
