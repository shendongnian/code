    vat now = DateTime.Now;
    var result = DocumentDAO.GetDocument()
                            .Where(d => d.ExpirationDate > now)
                            .Select(d => new {
                                               doc = d,
                                               firstname = d.User.FirstName,
                                               lastname = d.User.LastName
                                           });
