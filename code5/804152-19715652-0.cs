            List<Credentials> xmlResults = Root.Elements().Elements()
                .Select(element => new Credential() {
                       Username = element.Element("Username").Value,
                       Password = element.Element("Password").Value
                })
                .ToList();
            
