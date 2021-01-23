    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            User user = new User()
            {
                FirstName = "First",
                LastName = "Last"
            };
            // Alternative 1
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            // Alternative 2
            // DataContractSerializer serializer = new DataContractSerializer(typeof(User));
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                serializer.Serialize(writer, user);
                // alternative 2
                // serializer.WriteObject(writer, user);
            }
            // create XML from your data.
            return new OkXmlDownloadResult(builder.ToString(), "myfile.xml", this);
        }
    }
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
