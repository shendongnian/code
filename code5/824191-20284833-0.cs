    vat today = DateTime.Today;
    var result = context.DocumentsUI.Where(d => d.ExpirationDate > today)
                                    .Select(d => new {
                                                   doc = d,
                                                   firstname = d.User.FirstName,
                                                   lastname = d.User.LastName
                                               });
