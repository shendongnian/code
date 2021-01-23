    public class Action
    {
         public string action { get; set; }
         public string messageID { get; set; }
         public string round { get; set; }
         public Answer[] answers { get; set; }
    }
    
    public class Answer
    {
         public string longitude { get; set; }
         public string latitude { get; set; }
    }
    Action[] actions = JsonConvert.DeserializeObject<Action[]>(jsonString);
