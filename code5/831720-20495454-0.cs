        var client = new ServiceReference1.servercraPortTypeClient();
        client.ClientCredentials.UserName.UserName = "name";
        client.ClientCredentials.UserName.Password = "password";
        client.Homologadas("2");
        client.Close();
