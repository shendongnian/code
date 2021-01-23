     public class Client
     {
         public String Name { get; set; }
         public Contract SignedContract { get; set; }
         public Client(String name, Contract contract)
         {
             Name = name;
             SignedContract = contract;
         }
         public override string ToString()
         {
             return "Client " + Name;
         }
     }
