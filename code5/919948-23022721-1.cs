    ChannelFactory<IProductServiceTest> cf = new ChannelFactory<IProductServiceTest>(new WebHttpBinding(), "http://localhost:9000");
            cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
            IProductServiceTest channel = cf.CreateChannel();
            var test = channel.GetProductData("8");
            Console.WriteLine(test.ProductDescription);
            Console.Read();
