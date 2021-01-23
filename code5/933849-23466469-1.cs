    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            User user = new User()
            {
                FirstName = "First",
                LastName = "Last"
            };
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                serializer.Serialize(writer, user);
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
