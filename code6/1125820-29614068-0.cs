    public static class PersonMapper
    {
        public static PersonDTO ConvertToDTO(this Person person)
        {
            return new PersonDTO { ID = person.ID, Name = person.Name, Address = person.Address.ConvertToDTO() };
        }
    
        public static IEnumerable<PersonDTO> ConvertToDTO(this IEnumerable<Person> people)
        {
            return people.Select(person => person.ConvertToDTO());
        }
    }
    
    public static class AddressMapper
    {
        public static AddressDTO ConvertToDTO(this Address address)
        {
            return new AddressDTO { ID = address.ID, City = address.City };
        }
    
        public static IEnumerable<AddressDTO> ConvertToDTO(this IEnumerable<Address> addresses)
        {
            return addresses.Select(address => address.ConvertToDTO());
        }
    }
