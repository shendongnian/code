    public static class SendMailEx
    {
        public static Task SendMailExAsync(
            this System.Net.Mail.SmtpClient @this,
            System.Net.Mail.MailMessage message,
            CancellationToken token = default(CancellationToken))
        {
            // use Task.Run to negate SynchronizationContext
            return Task.Run(() => SendMailExImplAsync(@this, message, token));
        }
        private static async Task SendMailExImplAsync(
            System.Net.Mail.SmtpClient client, 
            System.Net.Mail.MailMessage message, 
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            var tcs = new TaskCompletionSource<bool>();
            System.Net.Mail.SendCompletedEventHandler handler = null;
            Action unsubscribe = () => client.SendCompleted -= handler;
            handler = async (s, e) =>
            {
                unsubscribe();
                // a hack to complete the handler asynchronously
                await Task.Yield(); 
                if (e.UserState != tcs)
                    tcs.TrySetException(new InvalidOperationException("Unexpected UserState"));
                else if (e.Cancelled)
                    tcs.TrySetCanceled();
                else if (e.Error != null)
                    tcs.TrySetException(e.Error);
                else
                    tcs.TrySetResult(true);
            };
            client.SendCompleted += handler;
            try
            {
                client.SendAsync(message, tcs);
                using (token.Register(() => client.SendAsyncCancel(), useSynchronizationContext: false))
                {
                    await tcs.Task;
                }
            }
            finally
            {
                unsubscribe();
            }
        }
    }
