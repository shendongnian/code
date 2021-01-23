    PreRequestFilters.Add((httpReq, httpRes) =>
                    {
                        //Handles Request and closes Responses after emitting global HTTP Headers
                        if (httpReq.Verb == "OPTIONS")
                        {
                            string origin = httpReq.Headers.Get("Origin");
                            if (origin != null)
                            {
                                httpRes.AddHeader(HttpHeaders.AllowOrigin, origin);
                            }
                            else
                            {
                                // Add the dev localhost header.
                                httpRes.AddHeader(HttpHeaders.AllowOrigin, "http://localhost:9000");
                            }
                            httpRes.EndRequest();
                        }
                    });
