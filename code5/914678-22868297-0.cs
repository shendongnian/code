        #region IPriceAssociationLookupRepository Members
        IEnumerable<IPriceAssociationLookupRepository> IPriceAssociationLookupRepository.GetPacs(string upc)
        {
            using (PortalDataEntities entities = new PortalDataEntities())
            {
                var priceAssociationLookups = (from priceassociationlookup in entities.PriceAssociationLookups
                                               where priceassociationlookup.Upc == this.Upc
                                               select priceassociationlookup);
                return priceAssociationLookups;
            }
        }
