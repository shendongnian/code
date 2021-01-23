    public List<OfferLocalizedContent> GetOffersWithContent(
           long customerId, int page, int pagesize)
    {
       ...
       var offers = this.ClientRepositoryBuilder
                        .OfferCLientRepository
                        .GetAllOffers(countryCode.Value, customerId)
                        .Skip(pagesize * page)
                        .Take(pagesize); // or you can do this in GetAllOffers
    }
