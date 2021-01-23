    public List<TableType.Person> GetData(TableType.Person type)
    {
        return new Domain.PersonList(_personRepository.Get());
    }
    
    public List<TableType.Event> GetData(TableType.Event type)
    {
         return new Domain.EventList(_eventRepository.Get());
    }
    public List<TableType.User> GetData(TableType.User type)
    {
         return new Domain.UserList(_userRepository.Get());
    }
