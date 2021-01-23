    class Address : MemberwiseEquatable<Address>
    {
      public Address(string street, string city)
      {
        Street = street;
        City = city;
      }
      public string Street { get; }
      public string City { get; }
    }
