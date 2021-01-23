    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    class ClientCredentialsDemo
    {
        static public void Main(string[] args)
        {
            XDocument document = XDocument.Parse(GetXml());
            var query =
                from el in document.Root.Elements("user")
                select new ClientCredentials
                    {
                        UserName = (string)el.Element("username"),
                        Password = (string)el.Element("password"),
                        Rights = (string)el.Element("rights")
                    };
    
            foreach (var cc in query)
            {
                Console.WriteLine
                    ("UserName:[{0}]\nPassword:[{1}]\nRights:[{2}]\n--",
                         cc.UserName,
                         cc.Password,
                         cc.Rights);
            }
        }
    
        static string GetXml()
        {
            return
                @"<?xml version='1.0' encoding='utf-8' ?> 
                  <users>
                    <user>
                        <username>playerone</username>
                        <password>654321</password>
                        <rights>true</rights>
                    </user>
                    <user>
                        <username>amoreroma</username>
                        <password>123456789</password>
                        <rights>false</rights>
                    </user>
                    <user>
                        <username>norights</username>
                        <password>20140215</password>
                    </user>
                  </users>";
        }
    }
    
    public class ClientCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rights { get; set; }
    }
