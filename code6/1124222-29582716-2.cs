    static class Extensions
    {
        public static bool IsSecure(this HttpResponseMessage message)
        {
            rreturn message.RequestMessage.RequestUri.Scheme == "https";
        }
    }
