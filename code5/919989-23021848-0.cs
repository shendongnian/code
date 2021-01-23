    if (!String.IsNullOrEmpty(textboxmvc))
        {
            var number = int.Parse(textboxmvc);
            student = student.Where(s => s.FirstName.ToUpper().Contains(textboxmvc.ToUpper())
                                       || s.LastName.ToUpper().Contains(textboxmvc.ToUpper())||s.Id==number);
    
        }
