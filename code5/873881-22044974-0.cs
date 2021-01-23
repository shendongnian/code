           //to order by SSN desc
            foreach (var e in payableObjects.OrderByDescending(e => e.SocialSecurityNumber))
            {
                Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.SocialSecurityNumber);
            }
            Console.WriteLine("");
            
            //to order by Lastname Asc
            foreach (var e in payableObjects.OrderBy(e => e.LastName))
            {
                Console.WriteLine(e.FirstName + " " + e.LastName + " " + e.SocialSecurityNumber);
            }
