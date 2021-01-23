            StringBuilder postData = new StringBuilder();
            postData.Append("USERNAME_FIELD_NAME =" + "USERNAME" + "&");
            postData.Append("PASSWORD_FIELD_NAME =" + "PASSWORD");
            // Now to Send Data.
            StreamWriter writer = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(THE_URL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.ToString().Length;
            try
            {
                writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData.ToString());
            HttpWebResponse WebResp = (HttpWebResponse)request.GetResponse();                     
            //Now, we read the response (the string), and output it.
            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            Console.WriteLine(_Answer.ReadToEnd());
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
