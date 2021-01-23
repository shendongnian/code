    here the case is of nested Serializaton:
    Better use following approach:
    [Serializable]
    public class person
    {
    public String Name;
    public Address HotelAddress;
    }
    [Serializable ]
    public class Address 
     {
      public string HotelName;
     }
