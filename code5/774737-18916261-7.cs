        private async Task<WebResponse> sampleRequest()
        {
            try
            {
                HttpWebRequest httpLoginRequest = (HttpWebRequest)WebRequest.Create(new Uri(DisplayMessage.Authentication_URL));
                httpLoginRequest.Method = DisplayMessage.Get_Method;
                Parameters = new Dictionary<string, string>();
                WebResponse webResponse =await httpLoginRequest.GetResponseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
