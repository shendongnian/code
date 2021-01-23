    static PersonDto()
    {
        Expression<Func<Person, Address>> addressSelector =
            person => person.Address;
        Selector = addressSelector.Compose(AddressDto.Selector)
                .Combine((entity, address) => new PersonDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Address = address,
                });
    }
