    public BindingList<string> CreateListDynamically(string _name)
    {
      List<UserDescriptor> output = new List<UserDescriptor>();
      foreach (xml.UserDescriptor dbList in xmlData.Users)
      {
        if (dbList.DatabaseDescriptorName == _name)
        {
          output.Add(new xml.UserDescriptor() { DatabaseDescriptorName = dbList.DatabaseDescriptorName, Username = dbList.Username, Password = dbList.Password, IsAdmin = dbList.IsAdmin });
        }
      }
      return output;
    }
