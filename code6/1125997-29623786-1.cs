    // controller
    [HttpPost] //FOR SEARCH (WORKING)
    public ActionResult Search(ContactSearchModel search)
    {
        List<Contact> contactsList;
        if (search != null)
        {
            var query = db.Contacts.AsQueryable();
            if(!string.IsNullOrEmpty(search.Nume))
                query = query.Where(x => x.Nume.Contains(search.Nume));
            if(!string.IsNullOrEmpty(search.Prenume))
                query = query.Where(x => x.Prenume.Contains(search.Prenume));
            if(!string.IsNullOrEmpty(search.Adresa))
                query = query.Where(x => x.Adresa.Contains(search.Adresa));
            if(!string.IsNullOrEmpty(search.Mentiuni))
                query = query.Where(x => x.Mentiuni.Contains(search.Mentiuni));
            contactsList = query.ToList();
        }
        else
        {
            contactsList = db.Contacts.ToList();
        }
        return View(contactsList);
    }
