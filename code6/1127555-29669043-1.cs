    else
    {
        int loginAttempts;
        if (loginAttemptsByDeviceId.TryGetValue(deviceId, out loginAttempts)
        {
            loginAttemptsByDeviceId[deviceId] = ++loginAttempts;
        }
        else
        {
            loginAttemptsByDeviceId.Add(deviceId, 1);
        }
        return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
    }
