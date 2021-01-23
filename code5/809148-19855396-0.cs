    var binding = new System.ServiceModel.BasicHttpBinding();
    binding.SendTimeout = TimeSpan.FromMinutes( 1 );
    binding.OpenTimeout = TimeSpan.FromMinutes( 1 );
    binding.CloseTimeout = TimeSpan.FromMinutes( 1 );
    binding.ReceiveTimeout = TimeSpan.FromMinutes( 10 );
    using (var client = new SomeServiceSoapClient(binding, new System.ServiceModel.EndpointAddress("http://site.example/SomeService.asmx")))
    {
        // client.DoWork(...)
    }
    
