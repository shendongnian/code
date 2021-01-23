    ServiceReference1.SearchDataIndexSoapClient Client = new ServiceReference1.SearchDataIndexSoapClient();
            ServiceReference1.AuthHeader authHead = new ServiceReference1.AuthHeader();
            authHead.Password = "Admin";
            authHead.Username = "Admin";
            Client.Endpoint.Binding.SendTimeout= new TimeSpan(0, 5, 00);
            Console.WriteLine(client.StartIndex(authHead));
