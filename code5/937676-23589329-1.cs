        public ActionResult Edit(int id)
       {
        TAUX taux = db.TAUX.Find(id);
        if (taux == null)
        {
            return HttpNotFound();
        }
        ViewBag.CAT_ID = new SelectList(db.CATEGORIE, "CAT_ID", "LIBELLE", taux.CAT_ID);
        ViewBag.C_GARANT = new SelectList(db.GARANTIE, "C_GARANT", "LIB_ABREGE", taux.C_GARANT);
        return PartialView("_Edit",taux);
        }
