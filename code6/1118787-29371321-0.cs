    ServiceReference1.SearchDataIndexSoapClient Client = new ServiceReference1.SearchDataIndexSoapClient();
            ServiceReference1.AuthHeader authHead = new ServiceReference1.AuthHeader();
            authHead.Password = "Admin";
            authHead.Username = "Admin";
            authHead.ExtensionData = ExtensionData;
            Console.WriteLine(client.StartIndex(authHead));
