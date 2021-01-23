    public void TestDbConnection()
    {
      Task.Factory.StartNew(() =>
      {
        bool isAvailable = false;
        using(MyContext context = new MyContext())
        {
          var connection = ((IObjectContext)context).Connection as SqlConnection;
          try
          {
            connection.Open();
            isAvailble = true;
          }
          catch (Exception ex)
          {
          }
        }
        TestDbConnectionComplete(isAvailable);
      });
    }
    public void TestDbConnectionComplete(bool isAvailable)
    {
    }
