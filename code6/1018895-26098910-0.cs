    var server = from e in _fileElement.Elements("computerprefix")
                 where e.Attribute("name") != null
                 select new ServersLogins
                 {
                     Server = e.Attribute("name").Value,
                     Logins = new ObservableCollection(
                                  from i in e.Elements("user")
                                  select new Login
                                  {
                                      User = i.Attribute("name"),
                                      Password = i.Attribute("password")
                                  })
                 };
