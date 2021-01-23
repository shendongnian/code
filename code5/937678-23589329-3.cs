        public ActionResult Edit(int id=0, int cat_Id =0,c_garant=0)
       {
        if(id!=0 &&cat_id!=0 &&c_garant!=0)//regarding your error I put this to check
        TAUX taux = db.TAUX.Find(p=>p.TAUX_Id==id &&p.CAT_ID==cat_Id && p.C_GARANT==c_garant);
        if (taux == null)
        {
            return HttpNotFound();
        }
        ViewBag.CAT_ID = new SelectList(db.CATEGORIE, "CAT_ID", "LIBELLE", taux.CAT_ID);
        ViewBag.C_GARANT = new SelectList(db.GARANTIE, "C_GARANT", "LIB_ABREGE", taux.C_GARANT);
        return PartialView("_Edit",taux);
        }
