      using System.Collections.Generic;
      namespace RustyLazyLoadTester.Mobile.Models
      {
    public class RustyLazyLoadViewModel
    {
        public RustyLazyLoadViewModel()
        {
            Parameters = new Dictionary<string, object>();
        }
        public RustyLazyLoadViewModel(int limit, int fromRowNumber, string containerId,
            string ajaxActionUrl, IDictionary<string, object> parameters = null)
        {
            Limit = limit;
            FromRowNumber = fromRowNumber;
            ContainerId = containerId;
            AjaxActionUrl = ajaxActionUrl;
            if (parameters != null)
                Parameters = parameters;
        }
        public int Limit { get; set; }
        public int FromRowNumber { get; set; }
        public string ContainerId { get; set; }
        public string AjaxActionUrl { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
    }
    }
