        public class WebRequestor
        {
            public void MakeCall(DividendEvents dividends, Uri uri)
            {
                var postData = Serialize(dividends);
                var request = FormWebRequest(postData, uri);
                var response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                // Read the content of response, if you need to have to deserialize it (in the same way as Serialize method does serialization)
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            private static WebRequest FormWebRequest(string postData, Uri uri)
            {
                WebRequest request = WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "application/json";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                return request;
            }
            private static string Serialize(object data)
            {
                var stream1 = new MemoryStream();
                var testSer = new DataContractJsonSerializer(data.GetType());
                testSer.WriteObject(stream1, data);
                stream1.Seek(0, SeekOrigin.Begin);
                var sreader = new StreamReader(stream1);
                var cont = sreader.ReadToEnd();
                return cont;
            }
        }
