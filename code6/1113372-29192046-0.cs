    public class UserData
    {
        public string response { get; set; }
        public string error { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
    }
    UserData data = JsonConvert.DeserializeObject<UserData>(response);
