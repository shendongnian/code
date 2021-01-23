    public class MyHub : Hub {
        public async Task DoSomething() {
            var client = new SmtpClient();
            var message = new MailMessage(/* setup message here */);
            await TaskExt.WithNoContext(() => client.SendMailAsync(message));
        }
    }
 
    public static class TaskExt
    {
        static Task WithNoContext(Func<Task> func)
        {
            Task task;
            var sc = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                task = func();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(sc);
            }
            return task;
        }
    }
