    using CMS;
    using CMS.Tags;
    using CMS.Pages;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Globalization;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using iTextSharp.text;
    using iTextSharp.text.html;
    using iTextSharp.text.xml;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.draw;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.util;
    
    public class pdfPage : iTextSharp.text.pdf.PdfPageEventHelper
    {
    public override void OnEndPage(PdfWriter writer, Document doc)
    	{
    		PdfContentByte cb = writer.DirectContent;
    		cb.SetLineWidth(1f);
    		cb.SetCMYKColorStroke(66, 59, 57, 38);
    		cb.MoveTo(30, 55);     
    		cb.LineTo(doc.PageSize.Width - 30 , 55);     
    		cb.Stroke();
    		cb.MoveTo(185, 80);
    		cb.LineTo(185, 25);
    		cb.Stroke();
    		
    		ColumnText ct = new ColumnText(cb);
    		BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
    		Font times = new Font(bfTimes, 10);
    		times.SetColor(90, 90, 90);
    		ct.SetSimpleColumn(new Phrase("text text", times), 60, 60, 175, 78, 15, Element.ALIGN_MIDDLE);
    		ct.Go();
    		times.SetColor(1, 73, 144);
    		ct.SetSimpleColumn(new Phrase("text textn", times), 60, 38, 175, 55, 15, Element.ALIGN_MIDDLE);
    		ct.Go();
    		times.SetColor(90, 90, 90);
    		ct.SetSimpleColumn(new Phrase("text here", times), 190, 60, doc.PageSize.Width - 32 , 78, 15, Element.ALIGN_RIGHT);
    		ct.Go();
    		times.SetColor(90, 90, 90);
    		ct.SetSimpleColumn(new Phrase("text here", times), 190, 38, doc.PageSize.Width - 32 , 55, 15, Element.ALIGN_RIGHT);
    		ct.Go();
    	}
    }
