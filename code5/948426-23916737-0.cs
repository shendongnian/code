    public class Authorizer
    {
        private static Lazy<Task<AuthorizationInformation>> tcsFactory;
        static Authorizer()
        {
            tcsFactory = new Lazy<Task<AuthorizationInformation>>(
                () =>
                {
                    var tcs = new TaskCompletionSource<AuthorizationInformation>();
                    Dispatcher dispatcher = GetDispatcher();
                    dispatcher.BeginInvoke(new Action(() =>
                    {
                        var login = new LoginWindow();
                        login.ShowDialog();
                        var info = login.LoginInfo;
                        if (info != null)
                            tcs.TrySetResult(info);
                        else
                            tcs.TrySetException(new Exception("Failed to log in."));
                    }));
                    return tcs.Task;
                });
        }
        public static Task<AuthorizationInformation> Authorize()
        {
            return tcsFactory.Value;
        }
        private static Dispatcher GetDispatcher()
        {
            throw new NotImplementedException();
        }
    }
