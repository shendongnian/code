    [ChildActionOnly]
    public PartialViewResult Search() // for displaying the initial view with all contacts
    {
        IEnumerable<Contact> contactsList = db.Contacts;
        return PartialView("_Contacts", contactsList);
    }
    [HttpPost]
    public PartialViewResult Search(string searchNume)
    {
        // could make this IEnumerable<Contact> and avoid the extra overhead of .ToList()?
        List<Contact> contactsList; 
        if (string.IsNullOrEmpty(searchNume))
        {
            contactsList = db.Contacts.ToList();
        }
        else
        {
            contactsList = db.Contacts.Where(x => x.Nume.Contains(searchNume)).ToList();
        }
        return PartialView("_Contacts", contactsList); // partial view
    }
