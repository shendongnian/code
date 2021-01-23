    var query = DbContext.Clients
        .Where(c => c.FamilyNames.Any(fn => fn == textEnteredByUser))
        // only calls that can be converted to SQL safely here
        .Select(c => new {
            ClientName = c.Name,
            FamilyNames = c.FamilyNames
        })
        // force the query to be materialized so we can safely do other transforms
        .ToList()
        // convert the anon class to what we need
        .Select(anon => new ClientViewModel() {
            ClientName = anon.ClientName,
            // convert IEnumerable<string> to List<string>
            FamilyNames = anon.FamilyNames.ToList()
        });
