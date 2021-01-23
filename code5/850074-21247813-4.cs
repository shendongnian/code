            public DataSet getData(string strFoo)
        {
            string url = "foo";
            
            HttpClient client = new HttpClient();
            HttpResponseMessage response;   
            DataSet dsTable = new DataSet();
            try
            {
                   //Gets the headers that should be sent with each request
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                  //Returned JSON
                response = client.GetAsync(url).Result;
                  //converts JSON to string
                string responseJSONContent = response.Content.ReadAsStringAsync().Result;
                  //deserializes string to list
                var jsonList = DeSerializeJsonString(responseJSONContent);
                  //converts list to dataset. Bad name I know.
                dsTable = Foo_ConnectAPI.ExtentsionHelpers.ToDataSet<RootObject>(jsonList);
                  //Returns the dataset                
                return dsTable;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
           //deserializes the string to a list. Utilizes JSON.net. RootObject is a class that contains the get and set for the JSON elements
        public List<RootObject> DeSerializeJsonString(string jsonString)
        {
              //Initialized the List
            List<RootObject> list = new List<RootObject>();
              //json.net deserializes string
            list = (List<RootObject>)JsonConvert.DeserializeObject<List<RootObject>>(jsonString);
            return list;
        }
