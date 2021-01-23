            OnMessageOptions options = new OnMessageOptions();
    
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);
            try
            {
                client = Subscription.CreateClient();
                client.OnMessageAsync(MessageReceivedComplete, options);
            }
            catch (Exception ex)
            {
                throw new Exception (ex);
            }
