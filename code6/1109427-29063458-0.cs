    if (ModelState.IsValid)
    
                {
                    var infContainer = information.Information_Container;
                    dbContainer.Attach(infContainer);
    
                    infContainer.Informations.Add(information);
                    db.SaveChanges();
    
    
                    return RedirectToAction("Index");
                }
