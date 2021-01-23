    #region Referencing
    
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    
    #endregion
    
    namespace Stack
    {
        public class Program
        {
            public Program()
            {
                ErrorServer = ErrorServer.Deserialize( "path" );
            }
    
            public ErrorServer ErrorServer { get; set; }
    
            // This way you dont actually have to deal with LINQ and XML.
            // It's just as easy to create a few classes to hold your data, so you can use xml serialization.
            public User GetUserInfoByName( string name )
            {
                return
                    ErrorServer.Users.FirstOrDefault(
                        user => user.Username.Equals( name, StringComparison.CurrentCultureIgnoreCase ) );
            }
        }
    
        [Serializable]
        public class ErrorServer
        {
            public ClientIP ClientIP { get; set; }
    
            [XmlArrayItem( "User" )]
            public User[] Users { get; set; }
    
            public static ErrorServer Deserialize( string path )
            {
                using (var stream = new FileStream( path, FileMode.Open ))
                    return new XmlSerializer( typeof (ErrorServer) ).Deserialize( stream ) as ErrorServer;
            }
        }
    
        [Serializable]
        public class ClientIP
        {
            public bool AllowAll { get; set; }
    
            public string Address { get; set; }
        }
    
        [Serializable]
        public class User
        {
            public string Username { get; set; }
    
            public string Password { get; set; }
    
            public double NextError { get; set; }
    
            public bool Active { get; set; }
        }
    }
