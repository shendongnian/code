        public static string ParseExceptionRespose(WebException exception)
        {
            string responseContents;
            Stream descrption = ((HttpWebResponse)exception.Response).GetResponseStream();
            using (StreamReader readStream = new StreamReader(descrption))
            {
                responseContents = readStream.ReadToEnd();
            }
            return responseContents;
            
        }
