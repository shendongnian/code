    public class ClientInfo // you meant "class" right? since that clearly isn't a "value"
    {
        public string Name {get;set;} // use a property; don't use a name prefix
        public string Password {get;set;} // please tell me you aren't storing passwords
    }
    List<ClientInfo> clientList = new List<ClientInfo>(); // typed list
    public static void Serialize(List<ClientInfo> input) // typed list
    {
        if(input == null) throw new ArgumentNullException("input");
        XmlSerializer serializer = new XmlSerializer(typeof(List<ClientInfo>));
        using(TextWriter sw = new StreamWriter("users.txt")) // because: IDisposable
        {
            serializer.Serialize(sw, input);
            sw.Close();
        }
    }
