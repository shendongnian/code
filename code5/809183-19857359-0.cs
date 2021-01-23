                HttpResponseMessage response;
                string responseString = "";
    
                using (HttpClient client = new HttpClient())
                {
                    string url = mediaConfig.RequestUrl + String.Format(mediaConfig.GeoCodeStringFormat, lat, lon, distance);
    
                    if (mediaConfig.MediaName == "Twitter")
                        client.DefaultRequestHeaders.Add(mediaConfig.BearerTokenParamName, mediaConfig.BearerToken);
                    else if (mediaConfig.MediaName == "Instagram")
                        url = url + "&" + mediaConfig.BearerTokenParamName + "=" + mediaConfig.BearerToken;
                    else if (mediaConfig.MediaName == "GooglePlaces")
                        url = url + "&" + mediaConfig.BearerTokenParamName + "=" + mediaConfig.BearerToken;
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    
                    response = await client.GetAsync(url);
    
                    response.EnsureSuccessStatusCode();
                }
                responseString = await response.Content.ReadAsStringAsync();
