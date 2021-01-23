    public class Service
    {
       public Dictionary<int,string> StateDictonary {get;set;}
        public Service()
        {
          StateDictonary = new Dictionary<int,string>();
          StateDictonary[1] = "Active";
          StateDictonary[0] = "Inactive";
        }
    }
