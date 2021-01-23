    public static Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri startUri, Uri endUri)
    {
        if (options != WebAuthenticationOptions.None)
        {
            throw new NotImplementedException("This method does not support authentication options other than 'None'.");
        }
        WebAuthenticationBroker.StartUri = startUri;
        WebAuthenticationBroker.EndUri = endUri;
        WebAuthenticationBroker.AuthenticationInProgress = true;
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Facebook.Client;component/loginpage.xaml", UriKind.Relative));
        });
        Task<WebAuthenticationResult> task = Task<WebAuthenticationResult>.Factory.StartNew(() =>
        {
            authenticateFinishedEvent.WaitOne();
            return new WebAuthenticationResult(responseData, responseStatus, responseErrorDetail);
        });
        return task;
    }
