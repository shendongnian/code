    namespace WcfService1
    {
        public class Service1 : IService1
        {
            public List<RecommendPlace> getSearchCoords(string search)
            {
            
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.onemap.sg/API/services.svc/basicSearch?token=qo/s2TnSUmfLz+32CvLC4RMVkzEFYjxqyti1KhByvEacEdMWBpCuSSQ+IFRT84QjGPBCuz/cBom8PfSm3GjEsGc8PkdEEOEr&searchVal=" + search + "&returnGeom=1");
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                myResponse.Close();
                string coords;
                bool check = true;
                JObject doc = JObject.Parse(@result);
                using (JsonTextReader jsonReader = new JsonTextReader(new StringReader(result)))
                {
                    while (jsonReader.Read())
                    {
                        if ((string)jsonReader.Value == "ErrorMessage")
                        {
                            check = false;
                        }
                    }
                }
                if (check)
                {
                    coords = result;
                }
                else
                {
                    coords = "error";
                }
                return coords;
            }
        }
    }
