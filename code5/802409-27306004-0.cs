    public string SendMail(string fromAddress, string toEmail, string subject, string body)
        {
            //Construct the message
            var mailMessage = new System.Net.Mail.MailMessage(fromAddress, toEmail, subject, body);
            mailMessage.ReplyToList.Add(new MailAddress(fromAddress));
            //Specify whether the body is HTML
            mailMessage.IsBodyHtml = true;
            //Convert to MimeMessage
            MimeMessage message = MimeMessage.CreateFromMailMessage(mailMessage);
            var rawMessage = message.ToString();
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "GoogleClientId",
                    ClientSecret = "GoogleClientSecret"
                },
                Scopes = new[] { GmailService.Scope.GmailCompose }
            });
            var token = new Google.Apis.Auth.OAuth2.Responses.TokenResponse()
                {
                    AccessToken = MethodToRetrieveSavedAccessToken(),
                    RefreshToken = MethodToRetrieveSavedRefreshToken()
                };
            //In my case the username is the same as the fromAddress
            var gmail = new GmailService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    ApplicationName = "App Name",
                    HttpClientInitializer = new UserCredential(flow, fromAddress, token)
                });
            var result = gmail.Users.Messages.Send(new Message
                {
                    Raw = Base64UrlEncode(rawMessage)
                }, "me").Execute();
            return result.Id;
        }
        /// <summary>
        /// Converts input string into a URL safe Base64 encoded string. Method thanks to Jason Pettys.
        /// http://jason.pettys.name/2014/10/27/sending-email-with-the-gmail-api-in-net-c/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
