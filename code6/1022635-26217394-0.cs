    public interface IWebGrid
    {
        MvcHtmlString GetHtml(HtmlHelper helper);
    }
    public class WebGrid<TRow> : IWebGrid where TRow : WebGridRow
    {
        private ICollection<TRow> Rows {get;set;}
    
        public WebGrid(string tableId, IList<TRow> rows)
        {
            // Generate columns from Model (TRow) by reflection and add them to the rows property
        }
    
        public MvcHtmlString GetHtml(HtmlHelper helper) 
        {
            string returnString = "Generate opening tags for the table itself";
            foreach(TRow row in this.Rows)
            {
                // Generate html for every row
                returnString += row.GetHtml(helper);
            }
            returnString += "Generate closing tags for the table itself";
            return MvcHtmlString.Create(returnString);
        }
    }
    public abstract class WebGridRow
    {
        public virtual string GetRowId() 
        {
            return "row_" + Guid.NewGuid();
        }
    
        public abstract MvcHtmlString GetHtml(HtmlHelper helper);
    }
    public class MyRowModel : WebGridRow 
    {
        [CanFilter(false)]
        [CssClass("foo")]
        public string Name{get;set;}
    
        [CanFilter(true)]
        [CssClass("bar")]
        public int SomeOtherProperty{get;set;}
    
        public override MvcHtmlString GetHtml(HtmlHelper helper)
        {
            // Generate string for the row itself
        }
    }
