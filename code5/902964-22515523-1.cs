    string name;
    string id;
      
      
    public string Name
    {
        get { return name; }
        set { name= value; }
    }
      
    public string ID
    {
        get { return id; }
        set { id= value; }
    }
    
        {
         
                    var xElem = XElement.Load("XML/Users.xml");
        
                    var result=
                        from elem in xElem.Descendants("User")
                        orderby elem.Attribute("UserName").Value
                        select new User
                        {
                            Name = elem.Attribute("UserName").Value
                        };
        
                    
                }
    
           
