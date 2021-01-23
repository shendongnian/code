    Person person = publicationResolverService.GetPerson(personUri);
    if (author != null)
    {
        person.Id = personUri.ItemId.ToString();
    }
    else
    {
        person = _fakePerson;
    }
    return person;
