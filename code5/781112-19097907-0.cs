    [AcceptVerbs("PATCH")]
    public void Patch(int id, Delta<Person> person)
    {
        var personFromDb = _personRepository.Get(id);
        person.Patch(personFromDb);
        _personRepository.Save();
    }
