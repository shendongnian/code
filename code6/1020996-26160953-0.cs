    returnedViewModel.Add( 
        new ViewModelAllEventStacks
        {
            EventStack = item,
            AdminId = item.AdminEventLogs.FirstOrDefault().AdminId,
            ClientId = item.ClientEventLogs.FirstOrDefault().ClientId
        });
