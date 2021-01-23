    if (!String.IsNullOrEmpty(textboxmvc))
    {
        var id = int.Parse(textboxmvc)
        student = student.Where(s => s.FirstName.ToUpper().Contains(textboxmvc.ToUpper())
                                   || s.LastName.ToUpper().Contains(textboxmvc.ToUpper())
                                   || s.Id == id);
    }
