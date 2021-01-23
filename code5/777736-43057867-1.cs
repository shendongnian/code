    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using DataLayer;
    
    namespace DataMngt.MyCode
    {
        public class HeaderFooter : PdfPageEventHelper
        {
            #region Startup_Stuff
    
            private string[] _headerLines;
            private string _footerLine;
            
            private DefineFont _boldFont;
            private DefineFont _normalFont;
            
            private iTextSharp.text.Font fontTxtBold;
            private iTextSharp.text.Font fontTxtRegular;
    
            private int _fontPointSize = 0;
    
            private bool hasFooter = false;
            private bool hasHeader = false;
    
            private int _headerWidth = 0;
            private int _headerHeight = 0;
    
            private int _footerWidth = 0;
            private int _footerHeight = 0;
    
            private int _leftMargin = 0;
            private int _rightMargin = 0;
            private int _topMargin = 0;
            private int _bottomMargin = 0;
    
            private PageNumbers NumberSettings;
    
            private DateTime runTime = DateTime.Now;             
    
            public enum PageNumbers
            {
                None,
                HeaderPlacement,
                FooterPlacement
            }
    
            // This is the contentbyte object of the writer
            PdfContentByte cb;
            
            PdfTemplate headerTemplate;
            PdfTemplate footerTemplate;
            
            public string[] headerLines
            {
                get
                {
                    return _headerLines;
                }
                set
                {
                    _headerLines = value;
                    hasHeader = true;
                }
            }
    
            public string footerLine
            {
                get
                {
                    return _footerLine;
                }
                set
                {
                    _footerLine = value;
                    hasFooter = true;
                }
            }
                    
            public DefineFont boldFont
            {
                get
                {
                    return _boldFont;
                }
                set
                {
                    _boldFont = value;
                }
            }
    
            public DefineFont normalFont
            {
                get
                {
                    return _normalFont;
                }
                set
                {
                    _normalFont = value;
                }
            }
    
            public int fontPointSize
            {
                get
                {
                    return _fontPointSize;
                }
                set
                {
                    _fontPointSize = value;
                }
            }
    
            public int leftMargin
            {
                get
                {
                    return _leftMargin;
                }
                set
                {
                    _leftMargin = value;
                }
            }
    
            public int rightMargin
            {
                get
                {
                    return _rightMargin;
                }
                set
                {
                    _rightMargin = value;
                }
            }
    
            public int topMargin
            {
                get
                {
                    return _topMargin;
                }
                set
                {
                    _topMargin = value;
                }
            }
    
            public int bottomMargin
            {
                get
                {
                    return _bottomMargin;
                }
                set
                {
                    _bottomMargin = value;
                }
            }
    
            public int headerheight
            {
                get
                {
                    return _headerHeight;
                }
            }
    
            public int footerHeight
            {
                get
                {
                    return _footerHeight;
                }
            }
    
            public PageNumbers PageNumberSettings
            {
                get
                {
                    return NumberSettings;
                }
    
                set
                {
                    NumberSettings = value;
                }
            }
    
            #endregion
    
            #region Write_Headers_Footers
    
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                if (hasHeader)
                {
                    // left side is the string array passed in
                    // right side is a built in string array (0 = date, 1 = time, 2(optional) = page)
                    float[] widths = new float[2] { 90f, 10f };
                     
                    PdfPTable hdrTable = new PdfPTable(2);
                    hdrTable.TotalWidth = document.PageSize.Width - (_leftMargin + _rightMargin);
                    hdrTable.WidthPercentage = 95;
                    hdrTable.SetWidths(widths);
                    hdrTable.LockedWidth = true;
    
                    for (int hdrIdx = 0; hdrIdx < (_headerLines.Length < 2 ? 2 : _headerLines.Length); hdrIdx ++)
                    {
                        string leftLine = (hdrIdx < _headerLines.Length ? _headerLines[hdrIdx] : string.Empty);
                        
                        Paragraph leftPara = new Paragraph(5, leftLine, (hdrIdx == 0 ? fontTxtBold : fontTxtRegular));
    
                        switch (hdrIdx)
                        {
                            case 0:
                                {
                                    leftPara.Font.Size = _fontPointSize;
    
                                    PdfPCell leftCell = new PdfPCell(leftPara);
                                    leftCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    leftCell.Border = 0;
    
                                    string rightLine = string.Format(SalesPlanResources.datePara, runTime.ToString(SalesPlanResources.datePrintMask));
                                    Paragraph rightPara = new Paragraph(5, rightLine, (hdrIdx == 0 ? fontTxtBold : fontTxtRegular));
                                    rightPara.Font.Size = _fontPointSize;
    
                                    PdfPCell rightCell = new PdfPCell(rightPara);
                                    rightCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    rightCell.Border = 0;
    
                                    hdrTable.AddCell(leftCell);
                                    hdrTable.AddCell(rightCell);
                                    
                                    break;
                                }
    
                            case 1:
                                {
                                    leftPara.Font.Size = _fontPointSize;
    
                                    PdfPCell leftCell = new PdfPCell(leftPara);
                                    leftCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    leftCell.Border = 0;
    
                                    string rightLine = string.Format(SalesPlanResources.timePara, runTime.ToString(SalesPlanResources.timePrintMask));
                                    Paragraph rightPara = new Paragraph(5, rightLine, (hdrIdx == 0 ? fontTxtBold : fontTxtRegular));
                                    rightPara.Font.Size = _fontPointSize;
    
                                    PdfPCell rightCell = new PdfPCell(rightPara);
                                    rightCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    rightCell.Border = 0;
    
                                    hdrTable.AddCell(leftCell);
                                    hdrTable.AddCell(rightCell);
    
                                    break;
                                }
    
                            case 2:
                                {
                                    leftPara.Font.Size = _fontPointSize;
    
                                    PdfPCell leftCell = new PdfPCell(leftPara);
                                    leftCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    leftCell.Border = 0;
    
                                    string rightLine;
                                    if (NumberSettings == PageNumbers.HeaderPlacement)
                                    {
                                        rightLine = string.Concat(SalesPlanResources.pagePara, writer.PageNumber.ToString());
                                    }
                                    else
                                    {
                                        rightLine = string.Empty; 
                                    }
                                    Paragraph rightPara = new Paragraph(5, rightLine, fontTxtRegular);
                                    rightPara.Font.Size = _fontPointSize;
    
                                    PdfPCell rightCell = new PdfPCell(rightPara);
                                    rightCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    rightCell.Border = 0;
    
                                    hdrTable.AddCell(leftCell);
                                    hdrTable.AddCell(rightCell);
    
                                    break;
                                }
    
                            default:
                                {
                                    leftPara.Font.Size = _fontPointSize;
    
                                    PdfPCell leftCell = new PdfPCell(leftPara);
                                    leftCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    leftCell.Border = 0;
                                    leftCell.Colspan = 2;                               
    
                                    hdrTable.AddCell(leftCell);
                                    
                                    break;
                                }
                        }
                    }
                    
                    hdrTable.WriteSelectedRows(0, -1, _leftMargin, document.PageSize.Height - _topMargin, writer.DirectContent);
    
                    //Move the pointer and draw line to separate header section from rest of page
                    cb.MoveTo(_leftMargin, document.Top + 10);
                    cb.LineTo(document.PageSize.Width - _leftMargin, document.Top + 10);
                    cb.Stroke();
                }
    
                if (hasFooter)
                {
                    // footer line is the width of the page so it is centered horizontally 
                    PdfPTable ftrTable = new PdfPTable(1);
                    float[] widths = new float[1] {100 };
    
                    ftrTable.TotalWidth = document.PageSize.Width - 10;
                    ftrTable.WidthPercentage = 95;
                    ftrTable.SetWidths(widths);
    
                    string OneLine;
    
                    if (NumberSettings == PageNumbers.FooterPlacement)
                    {
                        OneLine = string.Concat(_footerLine, writer.PageNumber.ToString());
                    }
                    else
                    {
                        OneLine = _footerLine;
                    }
    
                    Paragraph onePara = new Paragraph(0, OneLine, fontTxtRegular);
                    onePara.Font.Size = _fontPointSize;
    
                    PdfPCell oneCell = new PdfPCell(onePara);
                    oneCell.HorizontalAlignment = Element.ALIGN_CENTER; 
                    oneCell.Border = 0;
                    ftrTable.AddCell(oneCell);
    
                    ftrTable.WriteSelectedRows(0, -1, _leftMargin, (_footerHeight), writer.DirectContent);
    
                    //Move the pointer and draw line to separate footer section from rest of page
                    cb.MoveTo(_leftMargin, document.PageSize.GetBottom(_footerHeight + 2));
                    cb.LineTo(document.PageSize.Width - _leftMargin, document.PageSize.GetBottom(_footerHeight + 2));
                    cb.Stroke();
                }
            }
    
            #endregion
    
    
            #region Setup_Headers_Footers_Happens_here
    
            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                // create the fonts that are to be used
                // first the hightlight or Bold font
                fontTxtBold = FontFactory.GetFont(_boldFont.fontFamily, _boldFont.fontSize, _boldFont.foreColor);
                if (_boldFont.isBold)
                {
                    fontTxtBold.SetStyle(Font.BOLD);
                }
                if (_boldFont.isItalic)
                {
                    fontTxtBold.SetStyle(Font.ITALIC);
                }
                if (_boldFont.isUnderlined)
                {
                    fontTxtBold.SetStyle(Font.UNDERLINE);
                }
    
                // next the normal font
                fontTxtRegular = FontFactory.GetFont(_normalFont.fontFamily, _normalFont.fontSize, _normalFont.foreColor);
                if (_normalFont.isBold)
                {
                    fontTxtRegular.SetStyle(Font.BOLD);
                }
                if (_normalFont.isItalic)
                {
                    fontTxtRegular.SetStyle(Font.ITALIC);
                }
                if (_normalFont.isUnderlined)
                {
                    fontTxtRegular.SetStyle(Font.UNDERLINE);
                }
                
                // now build the header and footer templates
                try
                {
                    float pageHeight = document.PageSize.Height;
                    float pageWidth = document.PageSize.Width;
                    
                    _headerWidth = (int)pageWidth - ((int)_rightMargin + (int)_leftMargin);
                    _footerWidth = _headerWidth;
                    
                    if (hasHeader)
                    {
                        // i basically dummy build the headers so i can trial fit them and see how much space they take.
                        float[] widths = new float[1] { 90f };
    
                        PdfPTable hdrTable = new PdfPTable(1);
                        hdrTable.TotalWidth = document.PageSize.Width - (_leftMargin + _rightMargin);
                        hdrTable.WidthPercentage = 95;
                        hdrTable.SetWidths(widths);
                        hdrTable.LockedWidth = true;
    
                        _headerHeight = 0;
    
                        for (int hdrIdx = 0; hdrIdx < (_headerLines.Length < 2 ? 2 : _headerLines.Length); hdrIdx++)
                        {
                            Paragraph hdrPara = new Paragraph(5, hdrIdx > _headerLines.Length - 1 ? string.Empty : _headerLines[hdrIdx], (hdrIdx > 0 ? fontTxtRegular : fontTxtBold));
                            PdfPCell hdrCell = new PdfPCell(hdrPara);
                            hdrCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            hdrCell.Border = 0;
                            hdrTable.AddCell(hdrCell);
                            _headerHeight = _headerHeight + (int)hdrTable.GetRowHeight(hdrIdx);
                        }
    
                        // iTextSharp underestimates the size of each line so fudge it a little 
                        // this gives me 3 extra lines to play with on the spacing
                        _headerHeight = _headerHeight + (_fontPointSize * 3);
    
                    }
    
                    if (hasFooter)
                    {
                        _footerHeight = (_fontPointSize * 2);
                    }
    
                    document.SetMargins(_leftMargin, _rightMargin, (_topMargin + _headerHeight), _footerHeight);
    
                    cb = writer.DirectContent;
    
                    if (hasHeader)
                    {
                        headerTemplate = cb.CreateTemplate(_headerWidth, _headerHeight);
                    }
    
                    if (hasFooter)
                    {
                        footerTemplate = cb.CreateTemplate(_footerWidth, _footerHeight);
                    }
                }
                catch (DocumentException de)
                {
    
                }
                catch (System.IO.IOException ioe)
                {
    
                }
            }
    
            #endregion
    
            #region Cleanup_Doc_Processing
    
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);
    
                if (hasHeader)
                {
                    headerTemplate.BeginText();
                    headerTemplate.SetTextMatrix(0, 0);
    
                    if (NumberSettings == PageNumbers.HeaderPlacement)
                    {
                    }
    
                    headerTemplate.EndText();
                }
    
                if (hasFooter)
                {
                    footerTemplate.BeginText();
                    footerTemplate.SetTextMatrix(0, 0);
    
                    if (NumberSettings == PageNumbers.FooterPlacement)
                    {
                    }
                    
                    footerTemplate.EndText();
                }
            }
    
            #endregion
            
        }
    }
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace DataMngt.MyCode
    {
    
        // used to define the fonts passed into the header and footer class
        public struct DefineFont
        {
            public string fontFamily { get; set; }
            public int fontSize { get; set; }
            public bool isBold { get; set; }
            public bool isItalic { get; set; }
            public bool isUnderlined { get; set; }
            public BaseColor foreColor { get; set; }
        }
    }
