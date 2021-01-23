        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
                {
                    var myService = DuplexChannelFactory<IMyService>.CreateChannel(new CallbackImplementation(),
                                                                                   new WSDualHttpBinding(),
                                                                                   new EndpointAddress(
                                                                                       @"http://localhost:4653/myservice"));
                    myService.CallService();
                    string s = "";
                });
        }
