    var pred = PredicateBuilder.Create<SubExpertise>(s => s.Description == "x");
    pred = pred.Or(s => s.Description == "y");
    var customers = db.Customers
                      .Where(c => c.Expertises
                                   .Any(e => e.SubExpertises.AsQueryable()
                                              .Any(pred)));
