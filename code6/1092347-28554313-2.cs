                var termlist = (terms == "") ? new List<string>() : terms.Split(' ').ToList();
                var linqList = (from p in Person 
                                join a in Address on p.AddressID equals a.AddressID
                                where SearchTermMatch(termlist, new List<string>() { p.ContactName, p.EmailAddress, a.Street, a.City, a.State, a.Zipcode })
                                select new { p.ContactName, p.EmailAddress, a.Street, a.City, a.State, a.Zipcode });       
