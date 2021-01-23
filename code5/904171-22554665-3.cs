            public PersonDto Get(int id) {
                 Person instance = // repo stuff to get person from store/db
                 
                 //Manual way to map data from one object to the other.
                 var personDto = new PersonDto();
                 personDto.Id = instance.Id;
                 personDto.FirstName = instance.firstName;
                 personDto.Surname = instance.Surname;
                 personDto.RowVersion = instance.RowVersion;
                 return personDto;
                 // As mentioned I use AutoMapper for this, so the above becomes a 1 liner.
                 // **Beware** there is some configuration for this to work in this case you
                 // would have the following in a separate automapper config class.
                 // AutoMapper.CreateMap<Person, PersonDto>();
                 // Using AutoMapper all the above 6 lines done for you in this 1.
                 return Mapper.Map<Person, PersonDto>(instance);
            }
