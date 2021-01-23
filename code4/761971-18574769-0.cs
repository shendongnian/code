    public void ProcessItems()
    {
      var items = itemService.GetAll();
      var successItems = new List<Item>();
      var mailMessages = new List<MailMessage>();
      using(var scope = new TransactionScope())
      {
        foreach(var item in items)
        {
          itemService.UpdateOne(item);
          itemService.UpdateTwo(item);
          successItems.Add(item);
    
    // you still need try/catch handling for DB updates that fail... or maybe you want it all to fail.
        }
        scope.Complete()
      }
    
      mailMessages = successItems.Select(i => itemService.GenerateMailMessage).ToList();
      
      //Do stuff with mail messages
    
    }
         
