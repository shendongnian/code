    class Address { 
      // Properties 
    }
    class Account
    {
      //Other Properties
      Public int PermanentAddressId {get;set;}
      Public int CurrentAddressId {get;set;}
      Public Address Permanent { get; set; }
      Public Address Current { get; set; }
    }
    class Other
    {
      //Other Properties
      Public int OtherAddressId {get;set;}
      Public Address OtherAddress { get; set; }
    }
    
    class AccountMapping : EntityTypeConfiguration<Account>
    {
      Public AccountMapping()
      {
        ToTable("Account");
        //Others like HasKey
        HasRequired(a=>a.ParmanentAddress).WithMany().HasForeignKey(p=>p.PermanentAddressId);
        HasRequired(a=>a.CurrentAddress).WithMany().HasForeignKey(p=>p.CurrentAddressId);
      }
    }
    class OtherMapping : EntityTypeConfiguration<Other>
    {
       public OtherMapping()
       {
         HasRequired(a=>a.OtherAddress).WithMany().HasForeignKey(p=>p.OtherAddressId);
       }
    }
