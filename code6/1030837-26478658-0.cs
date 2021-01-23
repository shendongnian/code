     XNamespace ns1 = XNamespace.Get("http://fake.com/services");
     var readPromotion = from a in xx.Descendants(ns1 + "Promotion")
                                select new
                                {
                                    PromotionID = (string)a.Attribute("PromotionId"),
                                    EffectiveDate = (string)a.Attribute("EffectiveDate"),
                                    ExpirationDate = (string)a.Attribute("ExpirationDate"),
                                    PromotionStatus = (string)a.Attribute("PromotionStatus"),
                                    PromotionTypeName = (string)a.Attribute("PromotionTypeName"),
                                    Description = (string)a.Value
                                };
            foreach (var read in readPromotion)
            {
                // Read values
            }
