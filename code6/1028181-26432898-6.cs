    private string GetHtmlPage(string URL)
            {
                String strResult;
                WebResponse objResponse;
                WebRequest objRequest = HttpWebRequest.Create(URL);
                objResponse = objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    strResult = sr.ReadToEnd();
                    sr.Close();
                }
                return strResult;
            }
