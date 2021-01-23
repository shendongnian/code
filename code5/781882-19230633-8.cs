    Data.ScratchEntities context = new Data.ScratchEntities();
    Data.Person person = new Data.Person();
    person.Name = "Jane Smith";
    //Note the use of the external enumeration here
    person.Title = Enumerations.TitleEnum.Mrs;
    context.People.Add(person);
    context.SaveChanges();
