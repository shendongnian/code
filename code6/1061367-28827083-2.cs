    public class AzureLoginClass : IWebAuthenticationContinuable
    {
      
       public void CallAzureLogin
       {
           _authenticationContext.AcquireTokenAndContinue(resource, clientId, redirectUri, AuthContextDelegateMethod);
       }
       private void AuthContextDelegateMethod(AuthenticationResult result)
       {
          // Is now called when ContinueAcquireTokenAsync is called
       }
       public async void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
       {
          AuthenticationResult result = await _authenticationContext .ContinueAcquireTokenAsync(args);
       }
    }
