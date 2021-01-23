    using System;
    using Windows.Data.Json;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;
    
    namespace NotificationsEnabler.Tools {
    	class HttpJsonContent : IHttpContent {
    		IJsonValue jsonValue;
    		HttpContentHeaderCollection headers;
    
    		public HttpContentHeaderCollection Headers {
    			get { return headers; }
    		}
    
    		public HttpJsonContent(IJsonValue jsonValue) {
    			if (jsonValue == null) {
    				throw new ArgumentException("jsonValue cannot be null.");
    			}
    
    			this.jsonValue = jsonValue;
    			headers = new HttpContentHeaderCollection();
    			headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
    			headers.ContentType.CharSet = "UTF-8";
    		}
    	}
    }
