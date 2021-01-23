    class Program {
        static void Main(string[] args) {
            String xml = "<?xml version=\"1.0\"?>\r\n<response>\r\n<sessid>jsh5ekqnt39117tmu5gjebkku4</sessid>\r\n<session_name>Name Session</session_name>\r\n<user>\r\n<uid>2</uid>\r\n<vID>1</vID>\r\n<roleId>1</roleId>\r\n<username>mail@example.com</username>\r\n<password>password</password>\r\n<dateCreation>2013-05-14 00:00:00</dateCreation>\r\n<dateLastLogin>2013-09-06 09:22:10</dateLastLogin>\r\n<enabled>1</enabled>\r\n<multisession>1</multisession>\r\n<iddID>4</iddID>\r\n<iddName>Nome</iddName>\r\n<iddSurname>Cognome</iddSurname>\r\n<iddMobile>32222222</iddMobile>\r\n<iddEmail>mail@mail.mi</iddEmail>\r\n<iddTelephone></iddTelephone>\r\n<iddFax></iddFax>\r\n<iddNotice></iddNotice>\r\n<roles>manager</roles>\r\n</user>\r\n<result>1</result>\r\n</response>";
            Stream s = new MemoryStream(Encoding.Default.GetBytes(xml));
            XmlSerializer xs = new XmlSerializer(typeof(Response));
            Response loginResponseContract = (Response)xs.Deserialize(s);
            Console.WriteLine(loginResponseContract.User.iddName);
            Console.ReadKey();
        }
    }
    [Serializable, XmlRoot("response")]
    public class Response {
        [XmlElement("sessid")]
        public string SessionID { get; set; }
        [XmlElement("session_name")]
        public string SessionName { get; set; }
        [XmlElement("user")]
        public UserDetail User { get; set; }
        [XmlElement("response")]
        public int result { get; set; }
    }
    [Serializable]
    public class UserDetail {
        [XmlElement("uid")]
        public int ID { get; set; }
        [XmlElement("vID")]
        public int vID { get; set; }
        [XmlElement("roleId")]
        public int RoleID { get; set; }
        [XmlElement("username")]
        public string Username { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
        [XmlElement("dateCreation")]
        public string Creation { get; set; }
        [XmlElement("dateLastLogin")]
        public string LastLogin { get; set; }
        [XmlElement("enabled")]
        public int Enabled { get; set; }
        [XmlElement("multisession")]
        public int Multisession { get; set; }
        [XmlElement("iddID")]
        public string iddID { get; set; }
        [XmlElement("iddName")]
        public string iddName { get; set; }
        [XmlElement("iddSurname")]
        public string iddSurname { get; set; }
        [XmlElement("iddMobile")]
        public string iddMobile { get; set; }
        [XmlElement("iddEmail")]
        public string iddEmail { get; set; }
        [XmlElement("iddTelephone")]
        public string iddTelephone { get; set; }
        [XmlElement("iddFax")]
        public string iddFax { get; set; }
        [XmlElement("iddNotice")]
        public string iddNotice { get; set; }
        [XmlElement("roles")]
        public string Roles { get; set; }
    }
