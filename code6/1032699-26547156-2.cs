    Predicate<AutoCompleteRestultDto> orResultPredicate = 
        PredicateExtensions.False<AutoCompleteRestultDto>();
    if (FirstName == true || AllFields == true) {
        orResultPredicate=orResultPredicate.Or(firstNamePredicate); } 
    if (LastName == true || AllFields == true) { 
        orResultPredicate = orResultPredicate.Or(lastNamePredicate); }
    if (KnownAs == true || AllFields == true) { 
        orResultPredicate = orResultPredicate.Or(knownAsPredicate); }
    Func<AutoCompleteRestultDto, bool> funcOr = c => orResultPredicate(c);
    //
    IQueryable<AutoCompleteRestultDto> query; // initialized already
    var items = query.Where(funcOr).ToList(); 
