    public IDomainList GetData(TableType type)
    {
        switch (type)
        {
            case TableType.Person:
                return new Domain.PersonList(_personRepository.Get());
            case TableType.Event:
                return new Domain.EventList(_eventRepository.Get());
            case TableType.User:
                return new Domain.UserList(_userRepository.Get());
        }
    
        return null;
    }
