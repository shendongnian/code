    public void Add(int employeenumber, string fromdate, string todate)
        {
            string pdfFilePath = null;
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            try
            {
                pdfFilePath = Server.MapPath("~/yourpath/");
                //string pdfFilePath = Server.MapPath(".") + "/pdf/myPdf.pdf";
                //Create Document class object and set its size to letter and give space left, right, Top, Bottom  Margin
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                //Open Document to write
                doc.Open();
                Font font8 = FontFactory.GetFont("ARIAL", 7);
                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                var imageFilePath = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/8.jpg"));
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                //Resize image depend upon your need
                jpg.ScaleToFit(40f, 56f);
                //Give space before image
                jpg.SpacingBefore = 30f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_LEFT;
                doc.Add(jpg);
                //this is for get the month name and the year name frm the sql based on the passed date
                var dateresult = new SalaryDAL().Getmonthyear(fromdate);
                //getting the single property form the collection in c#//
                string contents = System.IO.File.ReadAllText(Server.MapPath("~/templates/salarypdf.htm"));
                var result = new SalaryDAL().GetSalaryReport(employeenumber, fromdate, todate);
                contents = contents.Replace("${CompanyName}", Convert.ToString(result.GetType().GetProperty("CompanyName").GetValue(result, null)));
                contents = contents.Replace("${month}", Convert.ToString(dateresult.GetType().GetProperty("Month").GetValue(dateresult, null)));
                contents = contents.Replace("${year}", Convert.ToString(dateresult.GetType().GetProperty("Year").GetValue(dateresult, null)));
                contents = contents.Replace("${EmployeeName}", Convert.ToString(result.GetType().GetProperty("EmployeeName").GetValue(result, null)));
                contents = contents.Replace("${AccNo}", Convert.ToString(result.GetType().GetProperty("BankAccNo").GetValue(result, null)));
                contents = contents.Replace("${empno}", Convert.ToString(result.GetType().GetProperty("employeeNo").GetValue(result, null)));
                contents = contents.Replace("${dptname}", Convert.ToString(result.GetType().GetProperty("Department").GetValue(result, null)));
                contents = contents.Replace("${bankname}", Convert.ToString(result.GetType().GetProperty("BankName").GetValue(result, null)));
                contents = contents.Replace("${pfno}", Convert.ToString(result.GetType().GetProperty("PFNo").GetValue(result, null)));
                contents = contents.Replace("${basic}", Convert.ToString(result.GetType().GetProperty("BasicAdd").GetValue(result, null)));
                contents = contents.Replace("${basic1}", Convert.ToString(result.GetType().GetProperty("BasicSub").GetValue(result, null)));
                contents = contents.Replace("${hra}", Convert.ToString(result.GetType().GetProperty("HRAAdd").GetValue(result, null)));
                contents = contents.Replace("${hra1}", Convert.ToString(result.GetType().GetProperty("HRASub").GetValue(result, null)));
                contents = contents.Replace("${lta}", Convert.ToString(result.GetType().GetProperty("LTAAdd").GetValue(result, null)));
                contents = contents.Replace("${lta1}", Convert.ToString(result.GetType().GetProperty("LTASub").GetValue(result, null)));
                contents = contents.Replace("${ta}", Convert.ToString(result.GetType().GetProperty("TAAdd").GetValue(result, null)));
                contents = contents.Replace("${ta1}", Convert.ToString(result.GetType().GetProperty("LTASub").GetValue(result, null)));
                contents = contents.Replace("${da}", Convert.ToString(result.GetType().GetProperty("DAAdd").GetValue(result, null)));
                contents = contents.Replace("${da1}", Convert.ToString(result.GetType().GetProperty("DASub").GetValue(result, null)));
                contents = contents.Replace("${bonus}", Convert.ToString(result.GetType().GetProperty("BonusAdd").GetValue(result, null)));
                contents = contents.Replace("${bonus1}", Convert.ToString(result.GetType().GetProperty("BonusSub").GetValue(result, null)));
                contents = contents.Replace("${pt}", Convert.ToString(result.GetType().GetProperty("PTAdd").GetValue(result, null)));
                contents = contents.Replace("${pt1}", Convert.ToString(result.GetType().GetProperty("PTSub").GetValue(result, null)));
                contents = contents.Replace("${pf}", Convert.ToString(result.GetType().GetProperty("PFAdd").GetValue(result, null)));
                contents = contents.Replace("${pf1}", Convert.ToString(result.GetType().GetProperty("PFSub").GetValue(result, null)));
                contents = contents.Replace("${other}", Convert.ToString(result.GetType().GetProperty("OtherAdd").GetValue(result, null)));
                contents = contents.Replace("${other1}", Convert.ToString(result.GetType().GetProperty("OtherSub").GetValue(result, null)));
                contents = contents.Replace("${ge}", Convert.ToString(result.GetType().GetProperty("GrossEarning").GetValue(result, null)));
                contents = contents.Replace("${gd}", Convert.ToString(result.GetType().GetProperty("GrossDeduction").GetValue(result, null)));
                contents = contents.Replace("${netslry}", Convert.ToString(result.GetType().GetProperty("NetSalary").GetValue(result, null)));
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
                foreach (var htmlElement in parsedHtmlElements)
                {
                    doc.Add(htmlElement as IElement);
                }
            }
            catch (DocumentException docEx)
            {
            }
            catch (IOException ioEx)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                doc.Close();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfFilePath + "");
                Response.WriteFile(pdfFilePath);
                Response.End();
            }
        }
