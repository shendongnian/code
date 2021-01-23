    public static class HtmlHelperExt
    {
        public static HelperFactory<TModel> Custom<TModel>(this HtmlHelper<TModel> helper)
        {
            return new HelperFactory<TModel>(helper);
        }
    }
