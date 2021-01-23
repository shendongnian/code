            /// <summary>
            /// Get URL With QueryString Dynamically
            /// </summary>
            /// <param name="url">URI With/Without QueryString</param>
            /// <param name="newQueryStringArr">New QueryString To Append</param>
            /// <returns>Return Url + Existing QueryString + New/Modified QueryString</returns>
            public string BuildQueryStringUrl(string url, string[] newQueryStringArr)
            {
                string plainUrl;
                var queryString = string.Empty;
    
                var newQueryString = string.Join("&", newQueryStringArr);
    
                if (url.Contains("?"))
                {
                    var index = url.IndexOf('?');
                    plainUrl = url.Substring(0, index); //URL With No QueryString
                    queryString = url.Substring(index + 1);
                }
                else
                {
                    plainUrl = url;
                }
    
                var nvc = HttpUtility.ParseQueryString(queryString);
                var qscoll = HttpUtility.ParseQueryString(newQueryString);
    
                var queryData = string.Join("&",
                    nvc.AllKeys.Where(key => !qscoll.AllKeys.Any(newKey => newKey.Contains(key))).
                        Select(key => string.Format("{0}={1}",
                            HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))).ToArray());
                //Fetch Existing QueryString Except New QueryString
    
                var delimiter = nvc.HasKeys() && !string.IsNullOrEmpty(queryData) ? "&" : string.Empty;
                var queryStringToAppend = "?" + newQueryString + delimiter + queryData;
    
                return plainUrl + queryStringToAppend;
            }        
