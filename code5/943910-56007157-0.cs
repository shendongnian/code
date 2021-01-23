    public class CustomReportRenderer
    {
        public static byte[] RenderReport(string reportPath, string rdlcDSName, DataTable rdlcDt, ReportParameter[] rptParams, string downloadFormat, out string mimeType, out string filenameExtension)
        {
            var assemblyDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            AppDomainSetup setup = new AppDomainSetup()
            {
                ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                LoaderOptimization = LoaderOptimization.MultiDomainHost,
                PrivateBinPath = assemblyDir
            };
            setup.SetCompatibilitySwitches(new[] { "NetFx40_LegacySecurityPolicy" });
            AppDomain _casPolicyEnabledDomain = AppDomain.CreateDomain("Full Trust", null, setup);
            try
            {
                FullTrustReportviewer rpt = (FullTrustReportviewer)_casPolicyEnabledDomain.CreateInstanceFromAndUnwrap(typeof(FullTrustReportviewer).Assembly.CodeBase, typeof(FullTrustReportviewer).FullName);
                rpt.Initialize(reportPath, rptParams);
                var bytes = rpt.Render(rdlcDSName, rdlcDt, downloadFormat, out mimeType, out filenameExtension);
                return bytes;
            }
            finally
            {
                AppDomain.Unload(_casPolicyEnabledDomain);
            }
        }
    }
    [Serializable]
    public class FullTrustReportviewer : MarshalByRefObject
    {
        private ReportViewer FullTrust;
        public FullTrustReportviewer()
        {
            FullTrust = new ReportViewer();
            FullTrust.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
        }
        public void Initialize(string reportPath, ReportParameter[] rptParams)
        {
            FullTrust.LocalReport.ReportPath = reportPath;
            FullTrust.LocalReport.SetParameters(rptParams);
        }
        public byte[] Render(string rdlcDSName, DataTable rdlcDt, string downloadFormat, out string mimeType, out string filenameExtension)
        {
            Warning[] warnings;
            string[] streamids;
            string encoding;
            FullTrust.LocalReport.DataSources.Add(new ReportDataSource(rdlcDSName, rdlcDt));
            var bytes = FullTrust.LocalReport.Render(downloadFormat, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            return bytes;
        }
    }
