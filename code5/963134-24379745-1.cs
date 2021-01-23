    foreach (User user in epUsers)
    {
        User currentUser = user;
        try
        {
             ThreadPool.QueueUserWorkItem(new WaitCallback(f =>
             {
                 DoRestCall(string.Format("MESSAGE-TYPE=UserEnrollmentCreate&PAYLOAD={0}",
                                          GenarateRequestUserData(currentUser)), true);
             }));
        }
        catch (Exception ex)
        {
            _logger.Error("Error in CreateUser " + ex.Message);
        }
    }
