    public ViewResult Search(string textboxmvc)
    {
        int parsedId;
        int.TryParse(textboxmvc, out parsedId);
        var student = from i in db.StudentSet  select i;
    
        if (!String.IsNullOrEmpty(textboxmvc))
        {
            student = student.Where(s => s.FirstName.ToUpper().Contains(textboxmvc.ToUpper())
                                       || s.LastName.ToUpper().Contains(textboxmvc.ToUpper())||s.Id==parsedId);
    
        }
    
         return View(student);
    
    }
