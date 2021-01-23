    public class MyHub : Hub
    {
        public void AHubMethod(string message)
        {
            
            MyExternalSingleton.InvokeAMethod(Context.ConnectionId); // Send the current clients connection id to your external service
        }
    }
