    public class User {
        public User(string json) {
            var jsonObject = Json.Decode(json);
            MyName = (string)jsonObject.user.name;
            MyTeamName = (string)jsonObject.user.teamname;
            MyEmail = (string)jsonObject.user.email;
            Players = (DynamicJsonArray) jsonObject.user.players;
        }
        public string MyName{ get; set; }
        public string MyTeamName  { get; set; }
        public string MyEmail{ get; set; }
        public Array Players { get; set; }
    }
