    ContactsDataContext db = new ContactsDataContext();
    var filteredContacts = db.Contacts.Where(x => x.Phone.Length > 0);
    GridView gv = new GridView();
    gv.DataSource = filteredContacts.ToList();
    gv.DataBind();
