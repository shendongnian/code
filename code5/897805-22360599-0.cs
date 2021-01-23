    public class Service
    {
        Dictonary<int,string> StateDictonary {get;set;}
        public Service()
        {
          StateDictonary = new Dictonary<int,string>();
          StateDictonary[1] = "Active";
          StateDictonary[0] = "Inactive";
        }
    }
