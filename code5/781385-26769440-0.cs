     private bool ValidarCaptcha(UsuarioMV usuarioMV)
        {
            Stream dataStream = null;
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                string captchaChallenge = usuarioMV.sCaptchaChallenge;
                string captchaResponse = usuarioMV.sCaptchaResponse;
                if (captchaChallenge != null
                    && captchaResponse != null)
                {
                    throw new Exception("Parametros captcha nulos.");
                }
                WebRequest request = WebRequest.Create("https://www.google.com/recaptcha/api/verify");
                request.Method = "POST";
                //Solicitud
                string strPrivateKey = System.Web.Configuration.WebConfigurationManager.AppSettings["RecaptchaPrivateKey"].ToString();
                NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
                outgoingQueryString.Add("privatekey", strPrivateKey);
                outgoingQueryString.Add("remoteip", "localhost");
                outgoingQueryString.Add("challenge", captchaChallenge);
                outgoingQueryString.Add("response", captchaResponse);
                string postData = outgoingQueryString.ToString();
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                //Respuesta
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                if (reader.ReadLine() != "true")
                {
                    string sLinea = reader.ReadLine();
                    //if the is another problem
                    if (sLinea != "incorrect-captcha-sol")
                    {
                        throw new Exception(sLinea);
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //Clean up the streams.
                if (reader != null)
                    reader.Close();
                if (dataStream != null)
                    dataStream.Close();
                if (response != null)
                    response.Close();
            }
        }
