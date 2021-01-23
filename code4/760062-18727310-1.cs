    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.Security;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.html;
    using iTextSharp.text.html.simpleparser;
    using System.IO;
    public partial class Objects_EventList : System.Web.UI.UserControl
    {
        public string city;
        public int showcount;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Load_Events();
        };
    }
    protected void Load_Events()
    {
        EventsDataContext edc = new EventsDataContext();
        var events = (from e in edc.tblEvents_Cafes
                      where e.EventDateTime >= DateTime.Now && e.VenueCity.Trim() == city.Trim() && (e.VenueName.Contains("Café") || e.VenueName.Contains("Cafe") )
                      orderby e.EventDateTime
                      select new {
                          EventName = e.EventName,
                          EventDate = e.EventDate,
                          EventTime = e.EventTime,
                          Description = edc.tblEvents_Cafe_Descriptions.OrderBy(d => d.Priority).Where(d => d.Keywords.ToLower() == e.EventName.ToLower()).Select(d => d.Description).First(), // edc.tblEvents_Cafe_Descriptions.OrderBy(d => d.Priority).Where(d => d.Keywords.ToLower() == e.EventName.ToLower() || d.Keywords.ToLower().CompareTo(e.EventName.ToLower()) >= 0).Select(d => d.Description).First()
                      }).Take(showcount);
        lstvwEvents.DataSource = events;
        lstvwEvents.DataBind();
    }
    
    protected void lstvwEvents_OnItemDataBound(Object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var tempevent = dataItem.DataItem;
            Type t = tempevent.GetType();
            DateTime tempdate;
            if (DateTime.TryParse((t.GetProperty("EventDate").GetValue(tempevent, null)).ToString(), out tempdate))
            {
                Literal ltrlShortDate = new Literal();
                ltrlShortDate = (Literal)e.Item.FindControl("ltrlShortDate");
                ltrlShortDate.Text = tempdate.ToString("MM/dd/yyyy");
            }
            if (DateTime.TryParse((t.GetProperty("EventTime").GetValue(tempevent, null)).ToString(), out tempdate))
            {
                Literal ltrlTimes = new Literal();
                ltrlTimes = (Literal)e.Item.FindControl("ltrlTimes");
                ltrlTimes.Text = tempdate.ToString("hh:mm tt");
            }
        }
     }
    
    //Begin gridview for pdf
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        gvEventCaf.AllowPaging = Convert.ToBoolean(rbPaging.SelectedItem.Value);
        EventsDataContext edc = new EventsDataContext();
        var events = (from f in edc.tblEvents_Cafes
                      where f.EventDateTime >= DateTime.Now && f.VenueCity.Trim() == city.Trim() && (f.VenueName.Contains("Café") || f.VenueName.Contains("Cafe"))
                      orderby f.EventDateTime
                      select new
                      {
                          EventName = f.EventName,
                          EventDate = f.EventDate,
                          EventTime = f.EventTime,
                          VenueName = f.VenueName,
                          Description = edc.tblEvents_Cafe_Descriptions.OrderBy(d => d.Priority).Where(d => d.Keywords.ToLower() == f.EventName.ToLower()).Select(d => d.Description).First(), // edc.tblEvents_Cafe_Descriptions.OrderBy(d => d.Priority).Where(d => d.Keywords.ToLower() == e.EventName.ToLower() || d.Keywords.ToLower().CompareTo(e.EventName.ToLower()) >= 0).Select(d => d.Description).First()
                      }).Take(showcount);
        gvEventCaf.DataSource = events;
        gvEventCaf.DataBind();
        //Create a table
        iTextSharp.text.Table table = new iTextSharp.text.Table(gvEventCaf.Columns.Count);
        table.Cellpadding = 5;
        //Set the column widths 
        int[] widths = new int[gvEventCaf.Columns.Count];
        for (int x = 0; x < gvEventCaf.Columns.Count; x++)
        {
            widths[x] = (int)gvEventCaf.Columns[x].ItemStyle.Width.Value;
            string cellText = Server.HtmlDecode(gvEventCaf.HeaderRow.Cells[x].Text);
            iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#25925c"));
            table.AddCell(cell);
        }
        table.SetWidths(widths);
        //Transfer rows from GridView to table
        for (int i = 0; i < gvEventCaf.Rows.Count; i++)
        {
            if (gvEventCaf.Rows[i].RowType == DataControlRowType.DataRow)
            {
                for (int j = 0; j < gvEventCaf.Columns.Count; j++)
                {
                    string cellText = Server.HtmlDecode(gvEventCaf.Rows[i].Cells[j].Text);
                    iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);
                    //Set Color of Alternating row
                    if (i % 2 != 0)
                    {
                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                    }
                    table.AddCell(cell);
                }
            }
        }
        //Create the PDF Document
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        Paragraph chunk = new Paragraph("Calendar of Events for " + city + "Cafe" );
        pdfDoc.Add(chunk);
        pdfDoc.Add(table);
        pdfDoc.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=CafeCalendar.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
        Response.End();
    }
    
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        gvEventCaf.PageIndex = e.NewPageIndex;
        gvEventCaf.DataBind();
    }
    }
    
