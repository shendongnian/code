    public ActionResult Termspage()
    {
      TermsEntities updateterms = new TermsEntities();
      var ID = Session["userID"];
       if (ID != null)
        {
            updateterms.usp_UpdateUserTerms(Convert.ToInt32(ID), true);
            updateterms.SaveChanges();
            return RedirectToAction("Detail", new {id=ID})
        }
      }
