    public class Combined
    {
     public List<OtherAction> otherActions{get; set;}
     public List<Action> actions{get; set;}
    }
    
    
    XmlSerializer xs = new XmlSerializer(typeof(List<Combined>));
    using (StreamWriter sw = new StreamWriter("CombinedActions.xml"))
    {
       xs.Serialize(sw, listCombinedActions);
    }
