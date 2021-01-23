    Predicate<AutoCompleteRestultDto> firstNamePredicate = 
        c => terms.Any(t => c.FirstName.ToLower().Contains(t.ToLower()));
    Predicate<AutoCompleteRestultDto> lastNamePredicate = 
        c => terms.Any(t => c.LastName.ToLower().Contains(t.ToLower()));
    Predicate<AutoCompleteRestultDto> knownAsPredicate = 
        c => terms.Any(t => c.KnownAs.ToLower().Contains(t.ToLower()));
    var all = new Predicate<AutoCompleteRestultDto>[] { 
        firstNamePredicate, 
        knownAsPredicate, 
        lastNamePredicate };
    //
    var items = query.Where(a => PredicateExtensions.OrAll(all)(a)).ToList();
    items = query.Where(a => PredicateExtensions.AndAll(all)(a)).ToList();
