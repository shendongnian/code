    Person person = null;
            
    var peopleThatChose =
        Session.QueryOver<Person>(() => person)
            .JoinQueryOver<Contract>(person => person.Contracts)
            .JoinQueryOver<Budget>(contract => contract.Budget)
            .JoinQueryOver<Choice>(budget => budget.Choice)
            .JoinQueryOver<ChosenBenefit>(choice => choice.ChosenBenefit)
                .Where(chosen => chosen.BenefitImplementation.Id == 77)
            .SelectList(list => list
                .Select(() => person.FirstName)
                .Select(() => person.LastName))
            .List<object[]>();
