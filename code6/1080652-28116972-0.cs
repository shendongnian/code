    (from c in svcContext.ContactSet join a in svcContext.AccountSet
    on c.ContactId equals a.PrimaryContactId.Id 
    select new {a=a,c=c}    ).ToList()
    .Where(c=>c.FullName.Normalize(NormalizationForm.FormD).Contains("Café"))
    .Select( x=> select new  {
                              account_name = x.a.Name,
                              contact_name = x.c.LastName
                             };)
