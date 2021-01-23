            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("Your URL");
            byte[] data = Encoding.UTF8.GetBytes("Post Input");
            request.Method = "POST";
            request.Accept = "application/json"; //you can set application/xml
            request.ContentType = "application/json";// you can set application/xml
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            StreamReader result = new StreamReader(resp.GetResponseStream());
            if( result !=null)
            {
            if(!string.IsNullorEmpty(result.ReadToEnd().ToString()))
            {
              MessageBox.Show(result.ReadToEnd().ToString());
            }
            }
