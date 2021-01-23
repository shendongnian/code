     public class serverBasicAuthentication : br.com.cra21.cramg.servercra
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(uri);
                if (PreAuthenticate)
                {
                    NetworkCredential networkcredential = base.Credentials.GetCredential(uri,"Basic");
                    if (networkcredential != null)
                    {
                        Byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkcredential.UserName + ":" + networkcredential.Password);
                        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                    }
                    else
                       throw new ApplicationException("No network credentials") ;
                }
                return request; 
            }
        }
