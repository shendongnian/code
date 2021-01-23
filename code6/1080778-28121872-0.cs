    	    string fbid = stTextBox1.Text;
            string ukey = stTextBox2.Text;
            string jumlah = "4";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "fbid=" + fbid + "&ukey=" + ukey + "&jumlah=" + jumlah; ;
            byte[] data = encoding.GetBytes(postData);
            WebRequest request = WebRequest.Create("http://dcvn-full.ga/test/dcgems.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
	        {
                stream.Write(data, 0, data.Length);
            }
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(stream))
            {
                int count=1;
                while(sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if(count>=21 && count<=25)
                    {
                        sb.AppendLine(line);
                    }
                    count++;
                    if (count > 25)
                        break;
                }
                stLabel4.Text = (sb.ToString());
            }
