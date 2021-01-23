        {
            var url = "http://jsonplaceholder.typicode.com/posts";
 
            var webClient = new WebClient();
            var responseStr = webClient.DownloadString(url);
 
            //JObject jResponse = JObject.Parse(responseStr);
            JArray jArray = JArray.Parse(responseStr);
 
 
            List<User> userList = new List<User>();
 
            foreach (var item in jArray)
            {
                User user = new User();
 
                user.UserID = Convert.ToInt32(item["userId"]);
                user.ID = Convert.ToInt32(item["id"]);
                user.Title = Convert.ToString(item["title"]);
                user.Body = Convert.ToString(item["body"]);
 
                userList.Add(user);
            }
 
 
 
 
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://jsonplaceholder.typicode.com/posts";
            var webClient = new WebClient();
            var responseStr = webClient.DownloadString(url);
            JArray jArray = JArray.Parse(responseStr);
           
 
 
            List<Class1> userList = new List<Class1>();
 
            foreach (var item in jArray)
            {
                Class1 user = new Class1();
               
 
                user.userId = Convert.ToInt32(item["userId"]);
                user.id = Convert.ToInt32(item["id"]);
                user.title = Convert.ToString(item["title"]);
                user.body = Convert.ToString(item["body"]);
 
                userList.Add(user);
            }
            Repeater1.DataSource = userList;
            Repeater1.DataBind();
            var myClass = _download_serialized_json_data<List<Class1>>(url);
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            //Stream stream1 = response.GetResponseStream();
            //StreamReader sr = new StreamReader(stream1);
            //string strsb = sr.ReadToEnd();
            //object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);
            DataContractJsonSerializer jsonSerializer =
                    new DataContractJsonSerializer(typeof(List<Class1>));
            object objResponse = jsonSerializer.ReadObject(ws.GetResponseStream());
            List<Class1> jsonResponse
            = objResponse as List<Class1>;
            List<Class1> photos = (List<Class1>)jsonSerializer.ReadObject(ws.GetResponseStream());
        }
 
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
 
 
 
}
