    public static class Helper {
        public static IHtmlString MakeGrid(this HtmlHelper html, IEnumerable<object> items, Type type) {
            // You can give even this signature:
            // public static IHtmlString MakeGrid(HtmlHelper html, object items, Type type)
            // But clearly items MUST be a collection of some type!
            return (IHtmlString)typeof(Helper).GetMethod("MakeGridInternal").MakeGenericMethod(type).Invoke(null, new object[] { html, items });
        }
        public static IHtmlString MakeGridInternal<T>(HtmlHelper html, IEnumerable<T> items) where T : class {
            return GridMvc.Html.GridExtensions.Grid<T>(html, items)
                     .Columns(CreateColumns)
                     .WithPaging(10);
        }
        public static void CreateColumns<T>(IGridColumnCollection<T> columns) {
            Type t = typeof(T);
            PropertyInfo title = t.GetProperty("Title");
            PropertyInfo description = t.GetProperty("Description");
            columns.Add(title)
                .Titled("MyTitle")
                .SetWidth(100);
            columns.Add(description)
                .Sortable(true);
        }
    }
