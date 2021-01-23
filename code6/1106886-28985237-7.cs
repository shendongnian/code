    var queryToList = (from ac in ctx.AuthorisationChecks
                           where wedNumbers.Contains(ac.WedNo)
                           orderby ac.WedNo, ac.ExpAuthDate, ac.ActAuthDate
                           select new 
                           {
                               Blah = ac.Blah
                           }).ToList();
