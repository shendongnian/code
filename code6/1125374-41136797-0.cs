    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using PDFExtraction;    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace PDFReplaceTextUsingItextSharp
    {
        public partial class ExtractPdf : System.Web.UI.Page
        {
            static iTextSharp.text.pdf.PdfStamper stamper = null;
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Replace_Click(object sender, EventArgs e)
            {
                string ReplacingVariable = txtReplace.Text; 
                string sourceFile = "Source File Path";
                string descFile = "Destination File Path";
                PdfReader pReader = new PdfReader(sourceFile);
                stamper = new iTextSharp.text.pdf.PdfStamper(pReader, new System.IO.FileStream(descFile, System.IO.FileMode.Create));
                PDFTextGetter("ExistingVariableinPDF", ReplacingVariable , StringComparison.CurrentCultureIgnoreCase, sourceFile, descFile);
                stamper.Close();
                pReader.Close();
            }
    
    
            /// <summary>
            /// This method is used to search for the location words in pdf and update it with the words given from replacingText variable
            /// </summary>
            /// <param name="pSearch">Searchable String</param>
            /// <param name="replacingText">Replacing String</param>
            /// <param name="SC">Case Ignorance</param>
            /// <param name="SourceFile">Path of the source file</param>
            /// <param name="DestinationFile">Path of the destination file</param>
            public static void PDFTextGetter(string pSearch, string replacingText, StringComparison SC, string SourceFile, string DestinationFile)
            {
                try
                {
                    iTextSharp.text.pdf.PdfContentByte cb = null;
                    iTextSharp.text.pdf.PdfContentByte cb2 = null;
                    iTextSharp.text.pdf.PdfWriter writer = null;
                    iTextSharp.text.pdf.BaseFont bf = null;
    
                    if (System.IO.File.Exists(SourceFile))
                    {
                        PdfReader pReader = new PdfReader(SourceFile);
    
    
                        for (int page = 1; page <= pReader.NumberOfPages; page++)
                        {
                            myLocationTextExtractionStrategy strategy = new myLocationTextExtractionStrategy();
                            cb = stamper.GetOverContent(page);
                            cb2 = stamper.GetOverContent(page);
    
                            //Send some data contained in PdfContentByte, looks like the first is always cero for me and the second 100, 
                            //but i'm not sure if this could change in some cases
                            strategy.UndercontentCharacterSpacing = (int)cb.CharacterSpacing;
                            strategy.UndercontentHorizontalScaling = (int)cb.HorizontalScaling;
    
                            //It's not really needed to get the text back, but we have to call this line ALWAYS, 
                            //because it triggers the process that will get all chunks from PDF into our strategy Object
                            string currentText = PdfTextExtractor.GetTextFromPage(pReader, page, strategy);
    
                            //The real getter process starts in the following line
                            List<iTextSharp.text.Rectangle> MatchesFound = strategy.GetTextLocations(pSearch, SC);
    
                            //Set the fill color of the shapes, I don't use a border because it would make the rect bigger
                            //but maybe using a thin border could be a solution if you see the currect rect is not big enough to cover all the text it should cover
                            cb.SetColorFill(BaseColor.WHITE);
    
                            //MatchesFound contains all text with locations, so do whatever you want with it, this highlights them using PINK color:
    
                            foreach (iTextSharp.text.Rectangle rect in MatchesFound)
                            {
                                //width
                                cb.Rectangle(rect.Left, rect.Bottom, 60, rect.Height);
                                cb.Fill();
                                cb2.SetColorFill(BaseColor.BLACK);
                                bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
    
                                cb2.SetFontAndSize(bf, 9);
    
                                cb2.BeginText();
                                cb2.ShowTextAligned(0, replacingText, rect.Left, rect.Bottom, 0);   
                                cb2.EndText();
                                cb2.Fill();
                            }
    
                        }
                    }
    
                }
                catch (Exception ex)
                {
    
                }
    
            }
    
        }
    }
