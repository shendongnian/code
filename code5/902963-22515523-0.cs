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
    
           
