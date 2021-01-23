      /// <summary>
        /// Handles frequently used functionalities in ReportViewer Controls to display SSRS reports locally.
        /// </summary>
        public class SSRSReport
        {
            private static String GetReportServerURL()
            {
                DataTable datatable = new DataTable();
    		
    	    //Execute the stored procedure to get the Report Server URL from the database.
                DBConnect.FillDataTable("GetSSRSReportServerURL", datatable, null);
                if (datatable == null || datatable.Rows.Count == 0)
                    return null;
                else
                    return datatable.Rows[0]["PARAMETER_VALUE"].ToString().Trim();
            }
    
            /// <summary>
            /// Open the SSRS report based on the name of the report specified.
            /// </summary>
            /// <param name="reportViewer">ReportViewer 
            /// object used to render the SSRS report on screen.</param>
            /// <param name="reportPath">Name of the Report 
            /// (.rdl) data uploaded on the server.</param>
            public static void DisplayReport(ReportViewer reportViewer, String reportPath)
            {
                try
                {
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    ServerReport serverreport = reportViewer.ServerReport;
                    ICredentials credentials = CredentialCache.DefaultCredentials;
                    ReportServerCredentials rscredentials = serverreport.ReportServerCredentials;
                    rscredentials.NetworkCredentials = credentials;
                    serverreport.ReportServerUrl = new Uri(GetReportServerURL());
                    serverreport.ReportPath = reportPath;
    
                    reportViewer.ShowParameterPrompts = false;
                    reportViewer.ShowPrintButton = true;
    
                    reportViewer.Refresh();
                    reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Open the SSRS report based on the name of the report and Report Parameters specified.
            /// </summary>
            /// <param name="reportViewer">ReportViewer 
            /// object used to render the SSRS report on screen.</param>
            /// <param name="reportPath">Name of the Report 
            /// (.rdl) data uploaded on the server.</param>
            /// <param name="reportParameterList">
            /// List of Report parameters.</param>
            public static void DisplayReport(ReportViewer reportViewer, 
            	String reportPath, List<ReportParameter> reportParameterList)
            {
                try
                {
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    ServerReport serverreport = reportViewer.ServerReport;
    
                    ICredentials credentials = CredentialCache.DefaultCredentials;
                    ReportServerCredentials rscredentials = serverreport.ReportServerCredentials;
                    rscredentials.NetworkCredentials = credentials;
                    serverreport.ReportServerUrl = new Uri(GetReportServerURL());
                    serverreport.ReportPath = reportPath;
    
                    reportViewer.ShowParameterPrompts = false;
                    reportViewer.ShowPrintButton = true;
    
                    if (reportParameterList != null)
                    {
                        foreach (ReportParameter param in reportParameterList)
                        {
                            serverreport.SetParameters(param);
                        }
                    }
    
                    reportViewer.Refresh();
                    reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Convert the SSRS report on the local report viewer to an Attachment. 
            /// This can be used to attach the PDF to an email.
            /// </summary>
            /// <param name="reportViewer">ReportViewer control.</param>
            /// <param name="fileName">Name of the PDF data.</param>
            /// <returns>PDF File as an Attachment that 
            /// can be attached to an email using SMTPClient.</returns>
            public static Attachment ConvertToPDFAttachment(ReportViewer reportViewer, String fileName)
            {
                try
                {
                    byte[] data;
                    if (reportViewer.ServerReport != null)
                        data = reportViewer.ServerReport.Render("PDF");
                    else
                        data = reportViewer.LocalReport.Render("PDF");
                    Attachment att = new Attachment(new MemoryStream(data), fileName);
                    return att;
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Saves the report from the local reportViewer as PDF. 
            /// To execute this method, the reportviewer needs to already contain the SSRS report.
            /// </summary>
            /// <param name="reportViewer">ReportViewer 
            /// control that displays the report.</param>
            /// <param name="filePath">Path of the file 
            /// to which the report should be stored as PDF.</param>
            /// <returns>True,if saved successfully ; False,otherwise.</returns>
            public static Boolean SaveAsPDF(ReportViewer reportViewer, String filePath)
            {
                try
                {
                    byte[] data;
                    if (reportViewer.ServerReport != null)
                        data = reportViewer.ServerReport.Render("PDF");
                    else
                        data = reportViewer.LocalReport.Render("PDF");
    
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                    return true;
                }
                catch(Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Saves the report from the SSRS Report Server as PDF.
            /// </summary>
            /// <param name="reportViewer">ReportViewer 
            /// control that displays the report.</param>
            /// <param name="filePath">Path of the file 
            /// to which the report should be stored as PDF.</param>
            /// <param name="reportPath">Name of the Report 
            /// (.rdl) data uploaded on the server.</param>
            /// <returns>True,if saved successfully ; False,otherwise.</returns>
            public static Boolean SaveAsPDF(ReportViewer reportViewer, String filePath, String reportPath)
            {
                try
                {
                    DisplayReport(reportViewer, reportPath);
                    byte[] data;
                    if (reportViewer.ServerReport != null)
                        data = reportViewer.ServerReport.Render("PDF");
                    else
                        data = reportViewer.LocalReport.Render("PDF");
    
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Saves the report from the SSRS Report Server as PDF.
            /// </summary>
            /// <param name="reportViewer">ReportViewer 
            /// control that displays the report.</param>
            /// <param name="filePath">Path of the file 
            /// to which the report should be stored as PDF.</param>
            /// <param name="reportPath">Name of the Report 
            /// (.rdl) data uploaded on the server.</param>
            /// <param name="reportParameterList">List of Report parameters.</param>
            /// <returns>True,if saved successfully ; False,otherwise.</returns>
            public static Boolean SaveAsPDF(ReportViewer reportViewer, 
            	String filePath, String reportPath, List<ReportParameter> reportParameterList)
            {
                try
                {
                    DisplayReport(reportViewer, reportPath,reportParameterList);
                    byte[] data;
                    if (reportViewer.ServerReport != null)
                        data = reportViewer.ServerReport.Render("PDF");
                    else
                        data = reportViewer.LocalReport.Render("PDF");
    
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 
