     public class Contract
     {
         public String ContractNumber { get; set; }
         public Contract(String contractNumber)
         {
             ContractNumber = contractNumber;
         }
         public override string ToString()
         {
             return "Contract Number :" + ContractNumber;
         }
     }
