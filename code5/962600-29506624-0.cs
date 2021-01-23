        public void Whatevermethod()
        {
            using (SP.ClientContext clientContext = new SP.ClientContext("http://server/collection"))
            {
                //Configure the handler to set FBA mode
                clientContext.ExecutingWebRequest += new EventHandler<SP.WebRequestEventArgs>(ctx_MixedAuthRequest);
                //Use the default mode to execute under the credentials of this process
                clientContext.AuthenticationMode = SP.ClientAuthenticationMode.Default;
                clientContext.Credentials = System.Net.CredentialCache.DefaultCredentials;
               
                clientContext.ExecuteQuery();
            }
        }
        private void ctx_MixedAuthRequest(object sender, SP.WebRequestEventArgs e)
        {
            try
            {
                //Add the header that tells SharePoint to use FBA
                e.WebRequestExecutor.RequestHeaders.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
