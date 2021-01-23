    using LinqKit;
    public static Expression<Func<Data.Models.Person, PersonViewModel>> Person = (p => new PersonViewModel()
        {
        FirstName = p.FirstName,
        LastName = p.LastName,
        Employer = DataMappers.EmployerMapper.Invoke(p.Employer)
        });
