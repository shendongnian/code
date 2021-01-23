    public partial class Person
    {
        ...
        public string override ToString()
        {
            return String.Format("{0} {1} {2}", Surname, Name, MiddleName).Trim();
        }
    }
    ...
    context.AppealPersons
        .GroupBy(ap => ap.Appeal.Id, ap => ap,
            (key, g) => new { 
                AppealId = key, 
                Appeal = g.FirstOrDefault().Appeal, 
                Persons = String.Join(",", g.Select(x => x.Person).AsEnumerable()
                    .Select(p => p.ToString()))
            })
        .ToList();
