    public void ProcessItems()
    {
      var items = itemService.GetAll();
      var mailMessages = new List<MailMessage>();
      bool committed = false;
      using(var scope = new TransactionScope())
      {
        foreach(var item in items)
        {
          itemService.UpdateOne(item);
          itemService.UpdateTwo(item);
        }
        scope.Complete()
        committed = true;
      }
      if (committed)
      {
        // Embed creation code and exception handling here.
        mailService.SendMail(mailMessages);
      }
    }
