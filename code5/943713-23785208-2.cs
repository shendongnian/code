                Select(c => new
                {
                    DiscountCardID = c.DiscountCardID,
                    CustomerID = c.CustomerID,
                    IssueDate = c.IssueDate,
                    ExpiryDate = c.ExpiryDate,
                    CustomerDiscountCardID = c.CustomerDiscountCardID
                }
                ).ToList().Select(c => new CustomerDiscountCard
                {
                    DiscountCardID = c.DiscountCardID,
                    CustomerID = c.CustomerID,
                    IssueDate = c.IssueDate,
                    ExpiryDate = c.ExpiryDate,
                    CustomerDiscountCardID = c.CustomerDiscountCardID
                })
