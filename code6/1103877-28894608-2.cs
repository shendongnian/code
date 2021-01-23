        public List<MyResultType> SearchByMethod1(int a, int b)
        {
            return (List<MyResultType>)SearchBy(new object[] { a, b }, "Method1");
        }
        public List<MyResultType2> SearchByMethod2(MyResultType b)
        {
            return (List<MyResultType2>)SearchBy(new object[] { b }, "Method1");
        }
        protected object SearchBy(object[] parameters, string method)
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
                return (List<MyResultType>)proxy.GetType().GetMethod(method).Invoke(proxy, parameters);
            }
            finally
            {
                CloseConnection(proxy, factory);
            }
        }
