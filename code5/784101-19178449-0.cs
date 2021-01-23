    IEnumerable<ContactPersonViewModel> contactPersons = 
        results.Select(p => new ContactPersonViewModel {
                           Name = p.Name,
                           Phone = p.Phone
                       });
