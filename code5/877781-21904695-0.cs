    public class MyReport : Telerik.Reporting.Report
    {
        public MyReport(string stylesheet)
        {
            this.ExternalStyleSheets.Clear();
            using (System.IO.Stream s = new System.IO.MemoryStream(File.ReadAllBytes(stylesheet)))
                this.ExternalStyleSheets.Add(new ExternalStyleSheet(s));
        }
    }
