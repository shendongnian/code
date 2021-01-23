    public static IHtmlString SortTableClickEvent(this HtmlHelper html, string url, string column)
    {
        string sortingPropertiesObject = string.Format(
            "onclick = \"James.Table.SortByColumn({{ url:'{0}', column:'{1}' }}, this);\""
            , url, column);
        return new HtmlString(sortingPropertiesObject);
    }
