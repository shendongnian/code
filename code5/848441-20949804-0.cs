    public static HtmlString SortTableClickEvent(this HtmlHelper html, string url, string column)
    {
        string sortingPropertiesObject;
        sortingPropertiesObject = "var properties = new James.prototype.Table.SortingProperties();";
        sortingPropertiesObject += "properties.url = '" + url + "';";
        sortingPropertiesObject += "properties.colName = '" + column + "';";
        sortingPropertiesObject += "onclick = 'James.Table.SortByColumn(properties, this);'";
        return sortingPropertiesObject ;
    }
