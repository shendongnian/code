    from i in _client.Interactions
    let program = x.Allocations.Where(y => y.Interaction_Id == x.Id)
                               .Select(a => a.Program).FirstOrDefault()
    let cat = x.Allocations.Select(a => a.Category).FirstOrDefault()
    select new InteractionDTO
        {         
           Id = x.Id,
           ClientName = x.Person.CorrespondenceName,
           Indepth = x.Indepth,
           Program = program == null ? null : program.Value,
           Category = cat == null ? null : cat.Value,
           ActivityDate = x.ActivityDate,
           Type = x.Type,
           Subject = x.Subject,
           LoanApplicationProvided = x.LoanApplicationProvided,
           BusinessPlanProvided = x.BusinessPlanProvided
        }
