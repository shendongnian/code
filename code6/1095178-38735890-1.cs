            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://xx1.bb.aa.com:636", "ldapsusername", "password",
                        AuthenticationTypes.SecureSocketsLayer);
            //directoryEntry.Options
            DirectorySearcher searcher = new DirectorySearcher(directoryEntry)
            {
                PageSize = int.MaxValue,
                Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=hp.wang))"
            };
            searcher.PropertiesToLoad.Add("sn");
            var result = searcher.FindOne();
            if (result == null)
            {
                return; // Or whatever you need to do in this case
            }
            string surname;
            if (result.Properties.Contains("sn"))
            {
                surname = result.Properties["sn"][0].ToString();
            }
