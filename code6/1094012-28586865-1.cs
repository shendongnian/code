    public static List<Person> GetStatusForPerson(List<Person> people, List<Status> statuses)
    {
        List<Person> peopleWithStatuses = new List<Person>();
        foreach (var p in people) 
        {
            Person person = new Person();
            person.PersonId = p.PersonId;
            person.Status = statuses.Where(s => s.StatusId == person.StatusId).FirstOrDefault());
     
            peopleWithStatuses.Add(person);
        }
        return peopleWithStatuses;
    }
