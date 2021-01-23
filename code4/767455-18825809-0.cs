    public ActionResult AutocompleteCollabo(string term)
        {
            int NumDossier = StructureData.DonneNumDossier((string)Session["NumCRPCEN"], (string)Session["MotDePasse"]);
            List<Contact> ListeContacts = StructureData.DonneListeElementDossier(NumDossier);
            var tabContactFull = ListeContacts.Where(contact => contact.Nom.Contains(term) || contact.Prenom.Contains(term) || contact.Fonction.Contains(term));
            var tabInfosUtiles = tabContactFull.Select(contact => new { label = contact.Nom + " " + contact.Prenom + " ("+contact.Fonction+") ", value = contact.Nom + " " + contact.Prenom + " ("+contact.Fonction+") ", id = contact.IdContact }).ToArray();
            // We set our needed informations with a title like "Label", "Value"
            // So the auto-complete can find by itself which data to display and which are for the value 
            return Json(tabInfosUtiles, JsonRequestBehavior.AllowGet);
        }
