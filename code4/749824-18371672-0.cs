    public bool Export(string accountNumber, DateTime settlementDateTime, string PDFfileName, out string errorMsg)
        {
            bool success;
            ReportViewer reportViewer;
            Warning[] warnings;
            ReportParameter[] rptParameters;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes;
            FileStream fs ;
    
            success = false;
            errorMsg = string.Empty;
            fs = null ;    
            reportViewer = null ;
            try
            {
                Console.Out.WriteLine(String.Format("Generando extracto para la cuenta \"{0}\" de la fecha {1}", accountNumber, settlementDateTime));
                reportViewer = new ReportViewer();
    
                // Set Processing Mode
                reportViewer.ProcessingMode = ProcessingMode.Remote;
    
                //set the URL of the report to execute
                reportViewer.ServerReport.ReportServerUrl = new Uri(repServerURL);
                reportViewer.ServerReport.ReportPath = repPath ;
    
                //Create the parameters that the report needs
                rptParameters = new ReportParameter[2];
    
                rptParameters[0] = new ReportParameter();
                rptParameters[0].Name = "rptPrm_AccountNumber";
                rptParameters[0].Values.Add(accountNumber);
    
                rptParameters[1] = new ReportParameter();
                rptParameters[1].Name = "rptPrm_Date";
                string dateAsString;
    
                dateAsString = settlementDateTime.ToString();
                rptParameters[1].Values.Add(dateAsString);
    
                reportViewer.ServerReport.SetParameters(rptParameters);
    
                // Process and render the report
                reportViewer.ServerReport.Refresh();
    
                //Render it to PDF and take the bytes to the FileStream
                bytes = reportViewer.ServerReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);
    
                fs = new FileStream(Path.Combine(exportPath, PDFfileName),FileMode.Create))
                fs.Write(bytes, 0, bytes.Length);
                success = true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Console.Error.WriteLine(String.Format("Se presento error al generar extracto para la cuenta \"{0}\" de la fecha {1}-{2}", accountNumber, settlementDateTime, errorMsg));
            }
            finally
            {
                if(fs != null)
                {
                    fs.Close(); 
                }
                if(reportViewer != null)
                {
                    reportViewer.Dispose(); 
                    reportViewer = null ;
                }
            }
    
            return success;
        }
    }
