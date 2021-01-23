	public static PersonDTO ToPersonDTOMap(Person person)
	{
		return new PersonDTO()
		{
			ID = person.ID,
			Name = person.Name,
			Address = new AddressDTO()
			{
				ID = person.Address.ID,
				City = person.Address.City
			}
		};
	}
