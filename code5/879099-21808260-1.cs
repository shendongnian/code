    var data = from item in doc.Descendants("user")
                select new User
                {
                    User = item.Element("username").Value,
                    ClientToken = item.Element("clientToken").Value,
                    AccessToken = item.Element("accessToken").Value,
                    UserUUID = item.Element("userUUID").Value,
                    PassLength = item.Element("lengthOfPass").Value
                };
    foreach (var thing in data) details = thing.ToString();
