       public MathResult GetResult(int a, int b) {
            var status = new MathResult();
            try {
                        var myBinding = new WSHttpBinding();
                        var myEndpoint =
                            new EndpointAddress(
                                new Uri("http://localhost:3980/"));
                        var myChannelFactory = new ChannelFactory<ICalculator>(myBinding, myEndpoint);
                        ICalculator client = myChannelFactory.CreateChannel();
                status = client.DoMathJson(a,b);
            } catch (Exception e) {
                //do something proper here 
            }
            return status;
        }
