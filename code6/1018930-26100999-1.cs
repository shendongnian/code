    var records = from x in xml.Descendants("record")
                  select new
                  {
                      awardDate = (string) x.Descendants("awardDate").FirstOrDefault().Value
                      ,userList = x.Descendants("user").Select(a=>new User
                      {
                            accessGrantedDate= a.Element("accessGrantedDate").Value,
                            emailAddress=a.Element("emailAddress").Value,
                            name=a.Element("name").Value,
                            phoneNumber=a.Element("phoneNumber").Value,
                            role = a.Element("role").Value
                      }).ToList()
                  };
