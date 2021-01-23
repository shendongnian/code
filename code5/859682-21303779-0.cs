     Public class Person
      {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set;}
         public DateTime BirthDate { get; set; }
         public bool IsMale { get; set; }
         public byte[] Image { get; set; }
         public byte[] RowVersion { get; set; }
         public virtual Person Parent { get; set; }
         public virtual ICollection<PhoneNumber> PhoneNumber { get; set; }
         public virtual ICollection<Address> Addresses { get; set; }
         public virtual  PersonInfo PersonInfo { get; set; }
      }
