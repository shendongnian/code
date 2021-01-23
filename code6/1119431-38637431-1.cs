    [Route("registration/request")]
    public async Task<IHttpResult> RegistrationRequest(Registration model)
    {
        try
        {
            MatrixLogManager.Info("Starting token creating.");
            var request = HttpContext.Current.Request;
            var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/Token";
            MatrixLogManager.Info("Checking if model is valid.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (MatrixServiceLayerLogin login = new MatrixServiceLayerLogin())
            {
                if (login.LoginUser(model.UserName, model.Password, true, true))
                {
                    var personId = login.GetPersonId();
                    MatrixLogManager.Debug("User " + model.UserName + "successfully logged in on MatrixSTS.");
                    try
                    {
                        using (var authRepo = new AuthRepository())
                        {
                            ApplicationUser appUser = new UserFactory().CreateApplicationUser(model, personId);
                            IdentityResult result = await authRepo.RegisterUser(appUser);
                            EMailService.SendEmail(appUser);
                            IHttpActionResult errorResult = GetErrorResult(result);
                            if (errorResult != null)
                            {
                                // MAJOR CHANGE here
                                return errorResult;
                            }
                            using (var client = new HttpClient())
                            {
                                var requestParams = new List<KeyValuePair<string, string>>
                                                    {
                                                        new KeyValuePair<string, string>("grant_type", "password"),
                                                        new KeyValuePair<string, string>("username", appUser.UserName),
                                                        new KeyValuePair<string, string>("password", "0000")
                                                    };
                                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                                var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                                var responseCode = tokenServiceResponse.StatusCode;
                                var responseMsg = new HttpResponseMessage(responseCode)
                                {
                                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                                };
                                responseMsg.Headers.Add("PSK", appUser.PSK);
                                return responseMsg;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MatrixLogManager.Error("Error: ", ex);
                        throw ex;
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
                }
            }
        }
        catch (Exception ex)
        {
            MatrixLogManager.Error(string.Format("Error while trying registring user: Exception = {0} InnerException {1}", ex.Message, ex.InnerException.Message));
            throw;
        }
    }
