    public ViewResult Search(string textboxmvc)
    {
        var student = from i in db.StudentSet  select i;
    
        if (!String.IsNullOrEmpty(textboxmvc))
        {
            int val = int.Parse(textboxmvc);
            student = student.Where(s => s.FirstName.ToUpper().Contains(textboxmvc.ToUpper())
                                       || s.LastName.ToUpper().Contains(textboxmvc.ToUpper())||s.Id==val);
    
        }
    
         return View(student);
    
    }
