    using DoddleReport;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using Font = iTextSharp.text.Font;
    
    namespace Test
    {
        public class PdfReportWriter // …
        {
            public static Font ConvertStyleToFont(ReportStyle reportStyle, string fontFamily)
            {
                var style = Font.NORMAL;
                if (reportStyle.Underline)
                {
                    style = Font.UNDERLINE;
                }
                else if (reportStyle.Bold || reportStyle.Italic)
                {
                    if (reportStyle.Bold && reportStyle.Italic)
                    {
                        style = Font.BOLDITALIC;
                    }
                    else if (reportStyle.Bold)
                    {
                        style = Font.BOLD;
                    }
                    else
                    {
                        style = Font.ITALIC;
                    }
                }
                
                // todo: to use this method you need to register your fonts at the beginning of the report
                // FontFactory.Register(@"c:\windows\fonts\myfont.ttf");
    
                return FontFactory.GetFont(
                    fontFamily, BaseFont.IDENTITY_H, BaseFont.EMBEDDED,
                    reportStyle.FontSize, style,
                    new BaseColor(reportStyle.ForeColor.R, reportStyle.ForeColor.G, reportStyle.ForeColor.B));
            }
        }
    }
