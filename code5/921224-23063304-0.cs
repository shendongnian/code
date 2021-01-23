    private MvcHtmlString GetCellHtml(HtmlHelper<TData> helper, TableColumn column, TData dataRow){
         TagBuilder cellTagBuilder = new TagBuilder("td");
         cellTagBuilder.InnerHtml = helper.Display(column.PropertyInfo.Name, dataRow);
         ...
    }
