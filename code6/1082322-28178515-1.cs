    public XmlDocument getDirections()
        {
            XmlTextReader xmlReader;
            XmlDocument xmlResponse = new XmlDocument();
            StringBuilder xmlResponseString = new StringBuilder();
            HttpWebRequest request =HttpWebRequest.Create(getRequestURL());
            using(HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        xmlResponse.Load(responseStream);
                    }
                }
            }            
            xmlResponse.LoadXml(xmlResponseString.ToString());
            return xmlResponse;
        }
