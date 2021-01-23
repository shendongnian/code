    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    namespace CamTheGeek
    {
        public class GenericWebApiClient<T> : IDisposable where T : class
        {
            HttpClient client = new HttpClient();
            Uri ServiceBaseUri;
            public GenericWebApiClient(Uri ServiceUri)
            {        
                if(ServiceUri == null)
                {
                    throw new UriFormatException("A valid URI is required.");
                }
                ServiceBaseUri = ServiceUri;
            }
            public List<T> GetAll()
            {
                var response = client.GetAsync(ServiceBaseUri).Result;
                if(response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<T>>().Result as List<T>;
                }
                else if (response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
                }
                return null;
            }
            public T GetById<I>(I Id)
            {
                if (Id == null)
                    return default(T);
                var response = client.GetAsync(ServiceBaseUri.AddSegment(Id.ToString())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result as T;
                }
                else if (response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException("Get failed with " + response.StatusCode.ToString());
                }
                return null;
            }
            public void Edit<I>(T t, I Id)
            {
                var response = client.PutAsJsonAsync(ServiceBaseUri.AddSegment(Id.ToString()), t).Result;
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("Edit failed with " + response.StatusCode.ToString());
            }
            public void Delete<I>(I Id)
            {
                var response = client.DeleteAsync(ServiceBaseUri.AddSegment(Id.ToString())).Result;
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("Delete failed with " + response.StatusCode.ToString());
            }
            public void Create(T t)
            {
                var response = client.PostAsJsonAsync(ServiceBaseUri, t).Result;
                if (!response.IsSuccessStatusCode)
                    throw new InvalidOperationException("Create failed with " + response.StatusCode.ToString());
            }
            public void Dispose(bool disposing)
            {
                if (disposing)
                {
                    client = null;
                    ServiceBaseUri = null;
                }
            }
            public void Dispose()
            {
                this.Dispose(false);
                GC.SuppressFinalize(this);
            }
            ~GenericWebApiClient()
            {
                this.Dispose(false);
            }
        }
        static class UriExtensions
        {
            public static Uri AddSegment(this Uri OriginalUri, string Segment)
            {
                UriBuilder ub = new UriBuilder(OriginalUri);
                ub.Path = ub.Path + ((ub.Path.EndsWith("/")) ? "" : "/") + Segment;
                return ub.Uri;
            }
        }
    }
