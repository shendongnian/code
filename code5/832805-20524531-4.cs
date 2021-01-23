    public class GetHtmlHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Grab the drop down list variable value from the query string
            // Use controls to build table or do it via StringWriter
            
            // Create a table row with three cells in it
            TableRow theTableRow = new TableRow();
            for (int theCellNumber = 0; theCellNumber < 3; theCellNumber++)
            {
                TableCell theTableCell = new TableCell();
                tempCell.Text = String.Format("({0})", theCellNumber);
                theTableRow.Cells.Add(theTableCell);
            }
            // Create writers to render contents of controls into
            StringWriter theStringWriter = new StringWriter();
            HtmlTextWriter theHtmlTextWriter = new HtmlTextWriter(theStringWriter);
            // Render the table row control into the writer
            theTableRow.RenderControl(theHtmlTextWriter);
            // Return the string via the StringWriter
            context.Response.Write(theStringWriter.ToString());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
