    //initialize client data(list)
            var ClientsData = new List<MapModel.ClientInfo>();
            //add one ClientInfo into ClientData
            ClientsData.Add(new MapModel.ClientInfo { Id = IDCounterDoctors, Languages = new Dictionary<int, List<string>>()});
            //set value to the first clientInfo's Language
            ClientsData[0].Languages.Add(2376, new List<string>() { "english", "french" });
