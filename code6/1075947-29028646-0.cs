            string json = null;
            byte[] bytes = null;
            string url = "https://app.asana.com/api/1.0/tasks";
            HttpWebRequest req = default(HttpWebRequest);
            Stream reqStream = default(Stream);
            string authInfo = null;
            Task TaskData = new Task();
            try
            {
                authInfo = apiKey + Convert.ToString(":");
                TaskData.workspace = WorkspaceId;
                TaskData.name = TaskName;
                TaskData.notes = TaskNotes;
                json = JsonConvert.SerializeObject(TaskData);
                json = json.Insert((json.Length - 1), ",\"projects\":[" + ProjectId + "]");
                json = Convert.ToString("{ \"data\":") + json + "}";
                bytes = Encoding.UTF8.GetBytes(json);
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = WebRequestMethods.Http.Post;
                req.ContentType = "application/json";
                req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
                req.ContentLength = bytes.Length;
                reqStream = req.GetRequestStream();
                reqStream.Write(bytes, 0, bytes.Length);
                reqStream.Close();
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                string res = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(res);
                Console.ReadLine();
                string finalString = res.Remove(0, 8);
                finalString = finalString.Remove((finalString.Length - 1));
                AsanaObjectId newtask = JsonConvert.DeserializeObject<AsanaObjectId>(finalString);
                return newtask;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                string resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                MessageBox.Show(resp);
                System.Environment.Exit(0);
            }
