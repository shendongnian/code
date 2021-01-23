            public List<MyResultType> SearchBy(string searchTerm, string method)
        {
            IFileService proxy = null;
            ChannelFactory<IFileService> factory = null;
            try
            {
                factory = new ChannelFactory<IFileService>("*");
                proxy = factory.CreateChannel();
                if (!IsMethodAllowed(method))
                {
                    throw new SecurityException();
                }
                return (List<MyResultType>)proxy.GetType().GetMethod(method).Invoke(proxy, new object[] { searchTerm });
                
            }
            finally
            {
                CloseConnection(proxy, factory);
            }
        }
