            var customerDtos = context.Customers.ToList().Select(c=> new CustomerDto
            {
                Id=c.ID, Area = c.Area, Name = c.FName + " " + c.LName, RegDate = c.Date.Format("yyyy-MM-dd"), Title = c.Gender == "M" ? "Mr" : "Ms"
            });
       
