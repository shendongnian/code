    foreach (User user in epUsers)
    {
        User currentUser = user;
        ThreadPool.QueueUserWorkItem(new WaitCallback(f =>
        {
            try
            {
                DoRestCall(string.Format("MESSAGE-TYPE=UserEnrollmentCreate&PAYLOAD={0}",
                                         GenarateRequestUserData(currentUser)), true);
            }
            catch (Exception ex)
            {
                _logger.Error("Error in CreateUser " + ex.Message);
            }
        }));
    }
