     public ActionResult EditContact(int? id)
     {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var Contact = db.Contacts.ToList();
        ViewBag.ContactIDList = new SelectList(PurchaseContact.AsEnumerable(), "ID", 
                                               "name", "Contact");
        ClientModel client= db.ClientModel.Find(id);
        ClientEditContactModel model = new ClientEditContactModel();
        model.ID = client.ID;
        model.ContactID = client.ContactID 
        return View(model);
    }
