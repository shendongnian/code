    [HttpGet]
    public object Lookups() {
        var countries = _breezeRepository.Get<Country>();
        var countinents = _breezeRepository.Get<Continent>();
        //more lookups in here           
        return new { countries, continents };
    }
