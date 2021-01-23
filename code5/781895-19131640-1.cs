    ....
    select new SomeModel
                                   {
                                       PersonName = c.FirstName + " " + c.LastName,
                                       IsAdmin = GetPermission(c.Email) // <-- This
                                   }
    ....
