    static class Extensions
    {
        public static bool IsSecure(this HttpResponseMessage message)
        {
            return message.RequestMessage.RequestUri.ToString().ToLower().StartsWith("https://");
        }
    }
