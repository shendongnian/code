    string xml = @"<?xml version='1.0' encoding='utf-8'?>
        <syncdata >
          <users >
            <user>
              <dn>JohnDoe</dn>      
            </user>
            <user>
              <dn>deleteme2</dn>      
            </user>
            <user>
              <dn>deleteme3</dn>      
            </user>
            <user>
              <dn>JohnSmith</dn>      
            </user> 
          </users>
          <groups>
        	<group name='group2'>     
              <users>
                <user>
                  <dn>JohnSmith</dn>
                </user>
              </users>
            </group>
            <group name='group1'>      
              <users>
                <user>
                  <dn>JohnDoe</dn>
                </user>
                <user>
                  <dn>JohnnyMorris</dn>
                </user>        
              </users>
            </group>
          </groups>
        </syncdata>  ";
        
        var doc = XDocument.Parse(xml); 
        										  
        var groupUsersList =  doc.Root.Element("groups")
                                       .Descendants("dn")
                                       .Select(x => (string)x)
        							   .ToList();
        
        var users = doc.Root.Element("users").Elements("user").ToList();
        foreach (var user in users )
        {
            if(!groupUsersList.Contains(user.Element("dn").Value))
                user.Remove();
        }
        
        Console.WriteLine(doc.ToString());
