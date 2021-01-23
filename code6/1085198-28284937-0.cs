    public class Accounts 
    {
        public List<Account> accounts{get;set;}
    
    }
    XmlSerializer xSer = new XmlSerializer(typeof(Accounts));
    var result = (Accounts) xSer.Deserialize(fs);
