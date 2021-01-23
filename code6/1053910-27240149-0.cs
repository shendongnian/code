    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    class AzureApiManagementHandler : DelegatingHandler
    {
        string _subscriptionKey;
        public AzureApiManagementHandler(string subscriptionKey)
        {
            _subscriptionKey = subscriptionKey;
        }
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var baseUri = new UriBuilder(request.RequestUri);
            string queryToAppend = string.Format("subscription-key={0}", _subscriptionKey);
            if (baseUri.Query != null && baseUri.Query.Length > 1)
                baseUri.Query = baseUri.Query.Substring(1) + "&" + queryToAppend;
            else
                baseUri.Query = queryToAppend;
            request.RequestUri = baseUri.Uri;
            return base.SendAsync(request, cancellationToken);
        }
    }
