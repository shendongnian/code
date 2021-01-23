            public ActionResult Edit(int id = 0)
            {
                Student student = db.Students.Find(id);
                var model = new StudentViewModel();
                model.Name = student.Name;
                model.Guardians = db.Guardians.ToList();
    
                //or if using repository then call the method that fetches
                //.. you the list of objects 
                //..and bind it to the StudentViewModel instance created.
    
                //Other Properties you need..fetch and assign them here..
                //model.StudentId= student.Id; ... etc
                
    
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(model); // return the viewModel instance.
            }
