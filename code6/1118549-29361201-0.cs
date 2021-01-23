     public class Account
     {
        [Key]
        public int Id {get;set;}
        ...
        public virtual PermanetAddress PermenentAddress {get;set;}
        public virtual CurrentAddress CurrentAddress {get;set;}
      }
      class Address
      {
         //properties
      }
      class PermanetAddress : Address
      {
         [ForeignKey("Account")]
         public int Id {get;set;}
         //properties
         public virtual Account account {get;set;}
      }
      class CurrentAddress : Address
      {
         [ForeignKey("Account")]
         public int Id {get;set;}
         //properties
         public virtual Account account {get;set;}
      }
