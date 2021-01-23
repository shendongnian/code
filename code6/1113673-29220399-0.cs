    public partial class ReportingService : DevReportService.ReportingService2010
    {
        /// <summary>
        /// Gets or sets the culture that is used when generating the report.
        /// </summary>
        /// <value>The culture that is used when generating the report.</value>
        public CultureInfo Culture { get; set; }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest request = base.GetWebRequest(uri);
            CultureInfo culture = this.Culture ?? CultureInfo.CurrentCulture;
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, culture.Name);
            return request;
        }
    }
