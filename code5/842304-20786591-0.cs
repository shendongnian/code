    using System.Web.Mvc;
    public class PaginationCustom
    {
        private UrlHelper _urlHelper;
        public PaginationCustom(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public string GetPagingMarkup()
        {
            //add your relevant html markup here
            string html = "<div>";
            string url = _urlHelper.Action("Index", "Invoices", new { id = 3 });
            html += url + "</div>";
            return html;
        }
    }
