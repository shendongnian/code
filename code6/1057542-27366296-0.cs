    public static class ExtensionMethods
    {
        public static Client GetClient(this AllTablesView view)
        {
            return new Client()
                       {
                           ClientID = view.ClientID,
                           ClientName = view.ClientName,
                       };
        }
    }
