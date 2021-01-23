    public static class HtmlExtensions
    {
        public static HtmlString HiddenOrDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> target, IEnumerable<SelectListItem> selectList)
        {
            if (selectList.Count() == 1)
                return helper.HiddenFor(target);
            return helper.DropDownListFor(target, selectList);
        }
    }
