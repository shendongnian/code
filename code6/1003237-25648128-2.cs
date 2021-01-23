    using System;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace SPORestClient
    {
        /// <summary>
        /// Client for performing CRUD operations against List resource in SharePoint Online (SPO) 
        /// </summary>
        public class ListsClient : IDisposable
        {
            public ListsClient(Uri webUri, ICredentials credentials)
            {
                _client = new WebClient();
                _client.Credentials = credentials;
                _client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                _client.Headers.Add(HttpRequestHeader.ContentType, "application/json;odata=verbose");
                _client.Headers.Add(HttpRequestHeader.Accept, "application/json;odata=verbose");
                WebUri = webUri;
            }
    
            public void InsertListItem(string listTitle, object payload)
            {
                var formDigestValue = RequestFormDigest();
                _client.Headers.Add("X-RequestDigest", formDigestValue);
                var endpointUri = new Uri(WebUri, string.Format("/_api/web/lists/getbytitle('{0}')/items", listTitle));
                var payloadString = JsonConvert.SerializeObject(payload);
                _client.Headers.Add(HttpRequestHeader.ContentType, "application/json;odata=verbose");
                _client.UploadString(endpointUri, "POST", payloadString);
            }
    
            /// <summary>
            /// Request Form Digest
            /// </summary>
            /// <returns></returns>
            private string RequestFormDigest()
            {
                var endpointUri = new Uri(WebUri, "_api/contextinfo");
                var result = _client.UploadString(endpointUri, "POST");
                JToken t = JToken.Parse(result);
                return t["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
            }
    
    
            public Uri WebUri { get; private set; }
    
            public void Dispose()
            {
                _client.Dispose();
                GC.SuppressFinalize(this);
            }
    
            private readonly WebClient _client;
    
        }
    }
