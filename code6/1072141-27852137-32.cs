        public static NameValueCollection CreateCollection()
        {
            NameValueCollection collection = new NameValueCollection();
            FillCollection(collection);
            return collection;
        }
        private static void FillCollection(NameValueCollection collection)
        {
            collection.Add("Sam", "Dot Net Perls");
            collection.Add("Bill", "Microsoft");
            collection.Add("Bill", "White House");
            collection.Add("Sam", "IBM");
        }
