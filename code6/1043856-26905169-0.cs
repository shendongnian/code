    string postData = string.Format("?FirstParameter=" + txt_First.Text + "&SecondParemeter=" + txt_Last.Text);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("..../api/customer/PostCustomer"/" + postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            request.ContentLength = data.Length;
          
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    var responseValue = string.Empty;
                    // grab the response  
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd(); // read the full response
                        }
                    }
                    if (responseValue != "")
                    {
                        //Do something here if response is not empty
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
