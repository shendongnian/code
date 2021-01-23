        private const string AppIdHeader = "AppId";
        private const string AppTokenHeader = "AppToken";
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            IEnumerable<string> appIdValues;
            IEnumerable<string> appTokenValues;
            HttpStatusCode responseCode = HttpStatusCode.OK;
            Guid AppIdGuid;
            var DoesHaveAppId = request.Headers.TryGetValues(AppIdHeader, out appIdValues);
            var DoesHaveAppToken = request.Headers.TryGetValues(AppTokenHeader, out appTokenValues);
            //Forces Json to be request Body type
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
            IPrincipal principal = null;
            if (DoesHaveAppId && DoesHaveAppToken)
            {
                if (Guid.TryParse(appIdValues.FirstOrDefault(), out AppIdGuid))
                {
                    principal = ValidateAuthentication(AppIdGuid, appTokenValues.FirstOrDefault());
                    if (principal != null) //Valid User
                    {
                        System.Threading.Thread.CurrentPrincipal = principal;
                        if (IsAppOverLimit(AppIdGuid))
                        {
                            responseCode = (HttpStatusCode)429;
                        }
                    }
                    else//User failed to authenticate
                        responseCode = HttpStatusCode.Unauthorized;
                }
            }
            else//User didn't supply Key/Token
                responseCode = HttpStatusCode.Forbidden;
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    if (responseCode == HttpStatusCode.OK)
                        return response;
                    else
                        return request.CreateResponse(responseCode);
                });
        }
    }
