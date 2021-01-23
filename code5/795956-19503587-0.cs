    public T GetData<T>()
    {
        if(typeof(T) == typeof(Domain.PersonList))
            return new Domain.PersonList(_personRepository.Get());
        else if (typeof(T) == typeof(Domain.EventList))
            return new Domain.EventList(_eventRepository.Get());
        else if (typeof(T) == typeof(Domain.UserList))
            return new Domain.UserList(_userRepository.Get());
        }
    
        return default(T);
    }
