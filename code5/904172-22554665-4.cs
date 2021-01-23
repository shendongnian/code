            public IEnumerable<ListPersonDto> ListOfPersons(QueryPersonDto dto = null)
            {
                // check dto and setup and querying needed
                // i wont go into that
                
                // Using link object mapping from the Person to ListPersonDto is even easier
                var listOfPersons = _personRep.Where(p => p.Surname == dto.Surname).Select(Mapper.Map<Person, ListPersonDto>).ToList();
                return listOfPersons;
            }
