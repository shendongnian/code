    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    int respcode = (int)response.StatusCode;
                    Assert.IsTrue(respcode == 302 || respcode == 200);
                    response.Close();
