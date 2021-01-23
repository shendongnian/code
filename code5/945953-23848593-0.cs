     public struct test
            {
                public bool isStudent;
                public string id;
                public string Username;
                public string Password;
            }
 
    List<test>  users = doc.Descendants("User").Where(e => e.Attribute("Id").Value == "123").Select(e => new test{ isStudent = true, id = e.Attribute("Id").Value, Username = e.Attribute("Username").Value, Password = e.Attribute("Username").Value }).ToList();
                  List<test>  admins = doc.Descendants("Admin").Where(e => e.Attribute("Id").Value == "123").Select(e => new test { isStudent = false, id = e.Attribute("Id").Value, Username = e.Attribute("Username").Value, Password = e.Attribute("Username").Value }).ToList();
                List<test> allTogether = users.Concat(admins).ToList();
                foreach (var xElement in allTogether)
                {
                   //check if xElement property isStudent is true
                }
