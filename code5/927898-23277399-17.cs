        try
        {
            var fact = new ChannelFactory<WcfService1.IService1>("NetTcpBinding_IService2");
            var proxy = fact.CreateChannel();
            var ves = proxy.GetData(1);
            Console.WriteLine(ves);
        }
        catch (FaultException<DivideByZeroException> exp)
        {
            Console.WriteLine(exp.Detail);
        }
