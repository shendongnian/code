     public Price GetPriceBySpecification(PriceSpecification specification)
        {
            var test_obj = from d in repository.DbPricing
                join d1 in repository.DbOfficeProducts on d.OfficeProductId equals d1.Id
                join d2 in repository.DbOfficeProductDetails on d1.ProductDetailsId equals d2.Id
                //select new <- anonymous object 
                select new Price
                {
                    PricingId = d.Id,
                    LetterColor = d2.LetterColor,
                    LetterPaperWeight = d2.LetterPaperWeight
                };
            if (specification.LetterColor.HasValue)
            {
                test_obj = test_obj.Where(c => c.LetterColor == specification.LetterColor.Value);
            }
            if (specification.LetterPaperWeight.HasValue)
            {
                test_obj = test_obj.Where(c => c.LetterPaperWeight == specification.LetterPaperWeight.Value);
            }
            // Convert found data into a C# object using a Factory class
            // Return awesome stuff
            throw new NotImplementedException();
        }
