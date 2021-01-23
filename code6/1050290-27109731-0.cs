    [HttpPost]
    public ActionResult CrearUsuario(Catastro_Cliente client)
    {
        if(Validator(client.document))
        {
            ModelState.AddModelError("NoDocument", "The document is invalid or not registered");
        }
    
        if(ModelState.IsValid)
        {
            // save to database of whatever
            // this is a successful response
            return RedirectToAction("Index");
        }
        // There's some error so return view with posted data:
        return View(client);
    }
