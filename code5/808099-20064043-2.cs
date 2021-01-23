    class RenderReport
        {
        
            public struct ReportServerCreds
                {
                    public string UserName { get; set; }
                    public string Password { get; set; }
                    public string Domain { get; set; }
                
                }
        
                public ReportServerCreds GetReportCreds()
                {
                    
                    ReportServerCreds rsc = new ReportServerCreds();
                    rsc.UserName = ConfigurationManager.AppSettings["reportserveruser"].ToString();
                    rsc.Password = ConfigurationManager.AppSettings["reportserverpassword"].ToString();
                    rsc.Domain = ConfigurationManager.AppSettings["reportserverdomain"].ToString();
        
                    return rsc;
                }
        
               public enum SSRSExportType
                { 
                    HTML,PDF
                }
        
                public string RenderReport(string reportpath,SSRSExportType ExportType)
                {
                    using (ReportExecutionService.ReportExecutionServiceSoapClient res = new   ReportExecutionService.ReportExecutionServiceSoapClient("ReportExecutionServiceSoap"))
                    {
        
                        ReportExecutionService.ExecutionHeader ExecutionHeader = new ReportExecutionService.ExecutionHeader();
                        ReportExecutionService.TrustedUserHeader TrusteduserHeader = new ReportExecutionService.TrustedUserHeader();
        
                        res.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
        
                        ReportServerCreds rsc = GetReportCreds();
                        res.ClientCredentials.Windows.ClientCredential.Domain = rsc.Domain;
                        res.ClientCredentials.Windows.ClientCredential.UserName = rsc.UserName;
                        res.ClientCredentials.Windows.ClientCredential.Password = rsc.Password;
                        
        
                        res.Open();
                        ReportExecutionService.ExecutionInfo ei = new ReportExecutionService.ExecutionInfo();
        
                        string format =null;
                        string deviceinfo =null;
                        string mimetype = null;
        
                        if (ExportType.ToString().ToLower() == "html")
                        {
                            format = "HTML4.0";
                            deviceinfo = @"<DeviceInfo><StreamRoot>/</StreamRoot><HTMLFragment>True</HTMLFragment></DeviceInfo>";
                        }
                        else if (ExportType.ToString().ToLower() == "pdf")
                        {
                            format = "PDF";
                            mimetype = "";
                        }
        
                        
                        byte[] results = null;
                        string extension = null;
                        string Encoding = null;
                        ReportExecutionService.Warning[] warnings;
                        string[] streamids = null;
                        string historyid = null;
                        ReportExecutionService.ExecutionHeader Eheader;
                        ReportExecutionService.ServerInfoHeader serverinfoheader;
                        ReportExecutionService.ExecutionInfo executioninfo;
        
        
        
                        // Get available parameters from specified report.
                        ParameterValue[] paramvalues = null;
                        DataSourceCredentials[] dscreds = null;
                        ReportParameter[] rparams = null;
        
                        using (ReportService.ReportingService2005SoapClient lrs = new ReportService.ReportingService2005SoapClient("ReportingService2005Soap"))
                        {
                            
                            
                            lrs.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                            lrs.ClientCredentials.Windows.ClientCredential.Domain = rsc.Domain;
                            lrs.ClientCredentials.Windows.ClientCredential.UserName = rsc.UserName;
                            lrs.ClientCredentials.Windows.ClientCredential.Password = rsc.Password;
                            
        
                            lrs.GetReportParameters(reportpath,historyid,false,paramvalues,dscreds,out rparams);
        
                        }
        
        
        
                        // Set report parameters here
                        //List<ReportExecutionService.ParameterValue> parametervalues = new List<ReportExecutionService.ParameterValue>();
        
                        //string enumber = Session["ENumber"] as string;
                        //parametervalues.Add(new ReportExecutionService.ParameterValue() { Name = "ENumber", Value = enumber });
        
                        //if (date != null)
                        //{
                        //    DateTime dt = DateTime.Today;
                            //parametervalues.Add(new ReportExecutionService.ParameterValue() { Name = "AttendanceDate", Value = dt.ToString("MM/dd/yyyy")});
                        //}
        
                        //if (ContainsParameter(rparams, "DEEWRID"))
                        //{
                            //parametervalues.Add(new ReportExecutionService.ParameterValue() { Name = "DEEWRID", Value = deewrid });
                        //}
        
                        //if (ContainsParameter(rparams, "BaseHostURL"))
                        //{
    //                        parametervalues.Add(new ReportExecutionService.ParameterValue() { Name = "BaseHostURL", Value = string.Concat("http://", Request.Url.Authority) });
                        //}
        
        
                        //parametervalues.Add(new ReportExecutionService.ParameterValue() {Name="AttendanceDate",Value=null });
                        //parametervalues.Add(new ReportExecutionService.ParameterValue() { Name = "ENumber", Value = "E1013" });
        
        
                        
                        try
                        {
        
                            Eheader = res.LoadReport(TrusteduserHeader, reportpath, historyid, out serverinfoheader, out executioninfo);
                            serverinfoheader = res.SetExecutionParameters(Eheader, TrusteduserHeader, parametervalues.ToArray(), null, out executioninfo);
                            res.Render(Eheader, TrusteduserHeader, format, deviceinfo, out results, out extension, out mimetype, out Encoding, out warnings, out streamids);
                            
                            string exportfilename = string.Concat(enumber, reportpath);
        
                            if (ExportType.ToString().ToLower() == "html")
                            {
                                //write html
                                string html = string.Empty;
                                html = System.Text.Encoding.Default.GetString(results);
        
                                html = GetReportImages(res, Eheader, TrusteduserHeader, format, streamids, html);
                                
                                return html;
                            }
                            else if (ExportType.ToString().ToLower() == "pdf")
                            {
                                //write to pdf
                                
        
                                Response.Buffer = true;
                                Response.Clear();
                                Response.ContentType = mimetype;
        
                                
        
                                //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.pdf", exportfilename));
                                Response.BinaryWrite(results);
                                Response.Flush();
                                Response.End();
        
                            }
        
        
                        }
                        catch (Exception e)
                        {
                            Response.Write(e.Message);
                        }
                    }
        
                }
        
        
                string GetReportImages(ReportExecutionService.ReportExecutionServiceSoapClient res, 
                                       ReportExecutionService.ExecutionHeader EHeader,
                                        ReportExecutionService.TrustedUserHeader tuh,
                                       string reportFormat, string[] streamIDs, string html)
                {
                    if (reportFormat.Equals("HTML4.0") && streamIDs.Length > 0)
                    {
                        string devInfo;
                        string mimeType;
                        string Encoding;
                        int startIndex;
                        int endIndex;
                        string fileExtension = ".jpg";
        
                        string SessionId;
        
                        Byte[] image;
                        
                        foreach (string streamId in streamIDs)
                        {
                            SessionId = Guid.NewGuid().ToString().Replace("}", "").Replace("{", "").Replace("-", "");
                            //startIndex = html.IndexOf(streamId);
                            //endIndex = startIndex + streamId.Length;
        
                            string reportreplacementname = string.Concat(streamId, "_", SessionId, fileExtension);
                            html = html.Replace(streamId, string.Concat(@"Report\GraphFiles\", reportreplacementname));
        
        
                            //html = html.Insert(endIndex, fileExtension);
                            //html = html.Insert(startIndex, @"Report/GraphFiles/" + SessionId + "_");
        
                            devInfo = "";
                            //Image = res.RenderStream(reportFormat, streamId, devInfo, out encoding, out mimeType);
                            res.RenderStream(EHeader,tuh, reportFormat, streamId, devInfo, out image , out Encoding, out mimeType);
        
        
        
                            System.IO.FileStream stream = System.IO.File.OpenWrite(HttpContext.Current.Request.PhysicalApplicationPath + "Report\\GraphFiles\\" + reportreplacementname);
                            stream.Write(image, 0, image.Length);
                            stream.Close();
                            mimeType = "text/html";
                        }
                    }
        
                    return html;
                }
        
                bool ContainsParameter(ReportParameter[] parameters, string paramname)
                {
                        if(parameters.Where(i=>i.Name.Contains(paramname)).Count() != 0)
                        {
                            return true;
                        }
                        return false;
                    }
        }
