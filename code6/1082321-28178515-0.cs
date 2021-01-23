    public XmlDocument getDirections()
        {
            XmlTextReader xmlReader;
            XmlDocument xmlResponse = new XmlDocument();
            StringBuilder xmlResponseString = new StringBuilder();
            HttpWebRequest request =HttpWebRequest.Create(getRequestURL());
            using(var response = request.GetResponse())
            {
                using(var responseStream = response.GetResponseStream())
                {
                    xmlResponse.Load(responseStream);
                }
            }                        
            return xmlResponse;
        }
