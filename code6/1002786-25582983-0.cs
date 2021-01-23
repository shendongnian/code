    public class Factory
    {
        public static CountryService CreateNewService()
        {
            return new CountryService(new CountryRepository());
        }
    }
