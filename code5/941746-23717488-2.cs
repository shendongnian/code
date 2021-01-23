    public static class XSocketClientExtensions
    {
        public static bool WaitForConnection(this XSocketClient client, int timeout=-1) {
            return SpinWait.SpinUntil(() => client.IsConnected, timeout);
        }
        public static void SetServerProperty(this XSocketClient client, string propertyName, object value) {
            client.Send(new { value = value }, "set_" + propertyName);
        }
    
        public static string GetServerProperty(this XSocketClient client, string propertyName) {
            var bindingName = "get_" + propertyName;
            // why event name is lowercase? 
            var eventName = bindingName.ToLowerInvariant();
            // we must be careful to preserve any existing binding on the server property
            var currentBinding = client.GetBindings().FirstOrDefault(b => b.Event == eventName);
            try {
                // only one binding at a time per event in the client
                if (currentBinding != null)
                    client.UnBind(bindingName);
                var waitEvent = new ManualResetEventSlim();
                string value = null;
                try {
                    client.Bind(bindingName, (e) => {
                        value = e.data;
                        waitEvent.Set();
                    });
                    // we must "Trigger" the reading of the property thru its "event" (get_XXX)
                    client.Trigger(bindingName);
                    // and wait for it to arrive in the callback
                    if (waitEvent.Wait(5000))
                        return value;
                    throw new Exception("Timeout getting property from XSockets controller at " + client.Url);
                } finally {
                    client.UnBind(bindingName);
                }
            } finally {
                // if there was a binding already on the "property getter", we must add it back
                if (currentBinding != null) 
                    client.Bind(bindingName, currentBinding.Callback);
            }
        }
    }
