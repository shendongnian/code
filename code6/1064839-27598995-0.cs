    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ParentVM viewModel)
    {
        if (ModelState.IsValid)
        {
            Court court = db.Courts.Find(viewModel.SelectedCourt);
            var parent = db.Parents.FirstOrDefault(x => x.ParentID == viewModel.ParentID);
            if (parent != null)
            {
                // Parent exists in DB --> You can just update it
                parent.FirstName = viewModel.FirstName;
                parent.LastName = view;
                Model.LastName;
                parent.ParentID = viewModel.ParentID;
                parent.Court = court;
            }
            else
            {
                // Parent does not exist in DB --> You have to Add a new Parent
                db.Parents.Add(new Parent()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    ParentID = viewModel.ParentID,
                    Court = court
                });
            }
    
            foreach (ChildVM item in viewModel.Children)
            {
                 // Here you can do exactly the same like you did bevore with your Parents
                 // First search for your Child in DB
                 var child = db.Childs.FirstOrDefault(x => x.ChildID == item.ChildID);
                 if (child != null)
                 {
                     child.Name = item.Name;
                     child.DOB = item.DOB;
                     child.Address = item.Address;
                     child.ParentID = viewModel.ParentID;
                     child.ChildID = item.ChildID;
                 }
                 else
                 {
                     db.Childs.Add(new Child()
                     {
                         Name = item.Name,
                         DOB = item.DOB,
                         Address = item.Address,
                         ParentID = viewModel.ParentID,
                         ChildID = item.ChildID
                     });
                 }
    
                 // Here I don't get what you want to do...
                 // Can you explain me that?
                 var findChild = db.Childs.Where(x => x.ParentID == viewModel.ParentID).ToList();
    
                 foreach (var item in findChild)
                 {
                     var deleteChild = viewModel.Children.Where(x => x.ChildID == item.ChildID).SingleOrDefault();
    
                     if (deleteChild == null)
                     {
                         db.Childs.Remove(item);
                     }
                 }
    
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             viewModel.CourtList = new SelectList(db.Courts, "CourtId", "CourtName");
             return View(viewModel);
         }
    }
