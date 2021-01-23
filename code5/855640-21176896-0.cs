    public class CurrentStatusWrapper 
    {
        public CurrentStatus CheckStatusResult {get; set;}
    }
    DataContractJsonSerializer obj = 
                          new DataContractJsonSerializer(typeof (CurrentStatusWrapper));
