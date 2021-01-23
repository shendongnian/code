    class ListMaker
    {
        public static List<ListingItem> getListing()
        {
            List<ListingItem> listing = new List<ListingItem>();
            for (int i = 0; i &lt; 100; i++)
            {
                listing.Add(new ListingItem());
            }
            return listing;
        }
    }
