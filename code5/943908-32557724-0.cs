    using Microsoft.Reporting.WebForms;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    //As you would expect, the new assembly WebReportviewer.FullTrustReportviewer
    //all it does is just run the report. that's it. here is the code, it should be in a separated project:
    
    namespace WebReportviewer
    {
        [Serializable]
        public class FullTrustReportviewer : MarshalByRefObject
        {
            private ReportViewer FullTrust;
            public FullTrustReportviewer()
            {
                FullTrust = new ReportViewer();
                FullTrust.ShowExportControls = false;
                FullTrust.ShowPrintButton = true;
                FullTrust.ShowZoomControl = true;
                FullTrust.SizeToReportContent = false;
                FullTrust.ShowReportBody = true;
                FullTrust.ShowDocumentMapButton = false;
                FullTrust.ShowFindControls = true;
                //FullTrust.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
                //FullTrust.LocalReport.SetBasePermissionsForSandboxAppDomain(new PermissionSet(PermissionState.Unrestricted));
            }
    
            public void Initialize(string DisplayName, string ReportPath, bool Visible, ReportParameter[] reportParam, string reportRenderFormat, string deviceInfo, string repMainContent, List<string[]> repSubContent)
            {
                FullTrust.LocalReport.DisplayName = DisplayName;
                FullTrust.LocalReport.ReportPath = ReportPath;
                //FullTrust.Visible = Visible;
                //FullTrust.LocalReport.LoadReportDefinition(new StringReader(repMainContent));
                FullTrust.LocalReport.SetParameters(reportParam);
    
                repSubContent.ForEach(x =>
                {
                    FullTrust.LocalReport.LoadSubreportDefinition(x[0], new StringReader(x[1]));
                });
                FullTrust.LocalReport.DataSources.Clear();
            }
    
            public byte[] Render(string reportRenderFormat, string deviceInfo)
            {
                return FullTrust.LocalReport.Render(reportRenderFormat, deviceInfo);
            }
            public void AddDataSources(string p, DataTable datatable)
            {
                FullTrust.LocalReport.DataSources.Add(new ReportDataSource(p, datatable));
            }
    
            public SubreportProcessingEventHandler SubreportProcessing { get; set; }
    
            public static void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
            {
                LocalReport lr = (LocalReport)sender;
    
                e.DataSources.Clear();
                ReportDataSource rds;
    
                if (e.ReportPath.Contains("DataTable2"))
                {
                    DataTable dt = (DataTable)lr.DataSources["DataTable2"].Value;
                    DataView dv = new DataView(dt);
                    dv.RowFilter = string.Format("Id={0}", e.Parameters["Id"].Values[0]);
                    rds = new ReportDataSource("DataTable2", dv.ToTable());
                    e.DataSources.Add(rds);
                }
            }
        }
    }
