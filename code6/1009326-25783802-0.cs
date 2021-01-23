            string response;
            try
            {
                using (StreamReader streamIn = new StreamReader((webRequest.GetResponse()).GetResponseStream()))
                {
                    response = streamIn.ReadToEnd();
                    streamIn.Close();
                }
            }finally
            {webRequest.Abort();}
           XDocument xDoc = XDocument.Parse(response);
