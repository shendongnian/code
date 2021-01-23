        public static void ChangeProxy(this HttpClientHandler handler, WebProxy newProxy)
        {
            if (handler.Proxy is WebProxy currentHandlerProxy)
            {
                currentHandlerProxy.Address = newProxy.Address;
                currentHandlerProxy.Credentials = newProxy.Credentials;
            }
            else
            {
                handler.Proxy = newProxy;
            }
        }
