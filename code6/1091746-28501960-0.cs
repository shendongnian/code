    public class Mail
    {
        public string ID { get; set; }
        public bool Status { get; set; }
    }
    
    //This is the root object, it's going to hold a collection of the mail
    public class MailCollection
    {
        public List<Mail> Mails { get; set; }
    }
    //we pass a type parameter telling it what type to deserialize to
    MailCollection result = Newtonsoft.Json.JsonConvert.DeserializeObject<MailCollection>(json);
    foreach (var item in result.Mails)
    {
        if (usermail == item.ID && item.Status) //since item.Status is a bool, don't compare to a string.
        {
            validUser = true;
            break;
        }
    }
