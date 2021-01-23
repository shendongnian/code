    static class HelperMethods
    {
        public static void ResetAll(this List<IYourInterface> collection)
        {
            collection.ForEach(x =>
            {
                x.Id = 0;
                x.Order_Id = 0;
            });
        }
    }
