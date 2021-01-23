    using System;
    using System.Linq;
    using System.Xml.Linq;
        
    namespace StackTesting
    {
        class Program
        {
            public class User
            {
             public string Username { get; set; }
             public string Pass { get; set; }
             public double Error { get; set; }
             public bool Active { get; set; }
        
              public User() { }
            }
        
            Public XDocument xDoc { get; set; }
            static void Main(string[] args)
            {
             xDoc = XDocument.Load(@"C:\Users\Trae\Documents\visual studio 2012\Projects\StackTesting\StackTesting\XMLFile1.xml");
              var user = (User) GetUserInfo("Admin");
            }
        
            public static User GetUserInfo(string UserName)
            {
              return xDoc.Root.Elements("Users").Elements()
                .Where(xe => xe.Element(XName.Get("Username")).Value == UserName)
                .Select(xe =>
                  new User
                  {
                    Username = xe.Element(XName.Get("Username")).Value,
                    Pass = xe.Element(XName.Get("Password")).Value,
                    Error = double.Parse(xe.Element(XName.Get("NextError")).Value),
                    Active = bool.Parse(xe.Element(XName.Get("Active")).Value)
                  }).ToArray()[0];
            }
        }
    }
