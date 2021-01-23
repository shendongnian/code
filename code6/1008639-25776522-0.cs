    if (ModelState.IsValid)
    {
      if (poste.Id == 3)
      {
        return RedirectToAction("Inscription", "Candidat");
      }
      ViewBag.Poste = _db.Postes.ToList(); // reassign collection for dropdown
      return View(poste);
    }
