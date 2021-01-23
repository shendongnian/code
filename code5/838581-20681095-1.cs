    public class AddressObject
    {
       public string Address {get; set;}
    }
    public class User
    {
       public int Id {get; set;}
       public List<AddressObject> adressList = new List<AddressObject>();
    }
