    static class PlaceDetailFactory
    {
        public static PlaceDetail create(Place p, string url, string phone, string site)
        {
            PlaceDetail pd = new PlaceDetail(p);
            pd.Url = url;
            pd.InternationalPhoneNumber = phone;
            pd.Website = site;
            return pd;
        }
    }
