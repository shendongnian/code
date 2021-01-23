    public IList<RetriveOperatorAcYo> GetRetriveOperatorListGrid(int Uid)
    {
        var persons = (from p in _Context.People
            join a in _Context.Accounts on p.PersonId equals a.PersonId
            join b in _Context.BusinessTypes on a.BusinessTypeId equals b.BusinessTypeId
            join d in _Context.AccountUserRelations on a.AccountId equals d.AccountId
            where b.Name == AccountBusinessTypes.Operator && a.IsDelete == false && d.Active == true && d.UserId == Uid
            select new 
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                MobileNumber = p.MobileNumber,
                LandlineNumber = p.LandlineNumber
             });
        return MapToRetirveOperatorYo(persons);
    }
    private IList<RetriveOperatorAcYo> MapToRetriveOperatorYoList(IEnumerable<dynamic> persons)
    {
        return persons.Select(MapToRetirveOperatorYo).ToList();
    }
    private RetriveOperatorAcYo MapToRetirveOperatorYo(dynamic person)
    {
        var vendorYo = new RetriveOperatorAcYo
        {
            Id = person.PersonId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            MobileNumber = person.MobileNumber,
            LandlineNumber = person.LandlineNumber
        }
        return vendorYo;
