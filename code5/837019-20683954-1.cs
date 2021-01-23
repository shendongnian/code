    namespace ABCPDFHtmlSignatureTest
    {
        using System;
        using System.Diagnostics;
        using System.IO;
        using System.Reflection;
        using iTextSharp.text;
        using iTextSharp.text.pdf;
        using WebSupergoo.ABCpdf8;
        /// <summary>
        /// The program.
        /// </summary>
        public class Program
        {
            /// <summary>
            /// The file name.
            /// </summary>
            private const string PdfFileName = @"c:\temp\pdftest.pdf";
            /// <summary>
            /// Adds a blank signature field at the specified location.
            /// </summary>
            /// <param name="pdf">The PDF.</param>
            /// <param name="signatureRect">The signature location.</param>
            /// <param name="signaturePage">the page on which the signature appears</param>
            /// <returns>The new PDF.</returns>
            private static byte[] AddBlankSignatureField(byte[] pdf, Rectangle signatureRect, int signaturePage)
            {
                var pdfReader = new PdfReader(pdf);
                using (var ms = new MemoryStream())
                {
                    var pdfStamper = new PdfStamper(pdfReader, ms);
                    var signatureField = PdfFormField.CreateSignature(pdfStamper.Writer);
                    signatureField.SetWidget(signatureRect, null);
                    signatureField.Flags = PdfAnnotation.FLAGS_PRINT;
                    signatureField.Put(PdfName.DA, new PdfString("/Helv 0 Tf 0 g"));
                    signatureField.FieldName = "ClientSignature";
                    signatureField.Page = signaturePage;
                    pdfStamper.AddAnnotation(signatureField, signaturePage);
                    pdfStamper.Close();
                    return ms.ToArray();
                }
            }
            /// <summary>
            /// The application entry point.
            /// </summary>
            /// <param name="args">
            /// The args.
            /// </param>
            public static void Main(string[] args)
            {
                var html = GetHtml();
                XRect signatureRect;
                int signaturePage;
                byte[] pdf;
                GetPdfUsingAbc(html, out pdf, out signatureRect, out signaturePage);
                /* convert to type that iTextSharp needs */
                var signatureRect2 = new Rectangle(
                    Convert.ToSingle(signatureRect.Left),
                    Convert.ToSingle(signatureRect.Top),
                    Convert.ToSingle(signatureRect.Right),
                    Convert.ToSingle(signatureRect.Bottom));
                pdf = AddBlankSignatureField(pdf, signatureRect2, signaturePage);
                /* save the PDF to disk */
                File.WriteAllBytes(PdfFileName, pdf);
                /* open the PDF */
                Process.Start(PdfFileName);
            }
            /// <summary>
            /// Returns the PDF for the specified html. The conversion is done using ABCPDF.
            /// </summary>
            /// <param name="html">The html.</param>
            /// <param name="pdf">the PDF</param>
            /// <param name="signatureRect">the location of the signature field</param>
            /// <param name="signaturePage">the page of the signature field</param>
            public static void GetPdfUsingAbc(string html, out byte[] pdf, out XRect signatureRect, out int signaturePage)
            {
                var document = new Doc();
                document.MediaBox.String = "A4";
                document.Color.String = "255 255 255";
                document.FontSize = 7;
                /* tag elements marked with "abcpdf-tag-visible: true" */
                document.HtmlOptions.AddTags = true;
                int pageId = document.AddImageHtml(html, true, 950, true);
                int pageNumber = 1;
                signatureRect = null;
                signaturePage = -1;
                TryIdentifySignatureLocationOnCurrentPage(document, pageId, pageNumber, ref signatureRect, ref signaturePage);
                while (document.Chainable(pageId))
                {
                    document.Page = document.AddPage();
                    pageId = document.AddImageToChain(pageId);
                    pageNumber++;
                    TryIdentifySignatureLocationOnCurrentPage(document, pageId, pageNumber, ref signatureRect, ref signaturePage);
                }
                pdf = document.GetData();
            }
            /// <summary>
            /// The try identify signature location on current page.
            /// </summary>
            /// <param name="document">The document.</param>
            /// <param name="currentPageId">The current page id.</param>
            /// <param name="currentPageNumber">The current page number.</param>
            /// <param name="signatureRect">The signature location.</param>
            /// <param name="signaturePage">The signature page.</param>
            private static void TryIdentifySignatureLocationOnCurrentPage(Doc document, int currentPageId, int currentPageNumber, ref XRect signatureRect, ref int signaturePage)
            {
                if (null != signatureRect) return;
                var tagIds = document.HtmlOptions.GetTagIDs(currentPageId);
                if (tagIds.Length > 0)
                {
                    int index = -1;
                    foreach (var tagId in tagIds)
                    {
                        index++;
                        if (tagId.Contains("ClientSignature"))
                        {
                            var rects = document.HtmlOptions.GetTagRects(currentPageId);
                            signatureRect = rects[index];
                            signaturePage = currentPageNumber;
                            break;
                        }
                    }                
                }
            }
            /// <summary>
            /// The get html.
            /// </summary>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public static string GetHtml()
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ABCPDFHtmlSignatureTest.HTMLPage1.html"))
                {
                    if (null == stream)
                    {
                        throw new InvalidOperationException("Unable to resolve the html");
                    }
                    using (var streamReader = new StreamReader(stream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
