    public ActionResult image(int id)
    {
         dbCRMEntities dbx = new dbCRMEntities();
         String img = dbx.CONTACTS.FirstOrDefault(Id => id == Id.CONTACT_ID);
         return base.File(img, "image/jpg");
    }
