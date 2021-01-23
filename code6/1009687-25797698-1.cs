    class AddressDTO
    {
       int Id {get; set;}
       int Name {get; set;}
       AddressDTO(Address addr)
       {
          this.Id = addr.Id;
          this.Name = addr.Name;
       }
    }
