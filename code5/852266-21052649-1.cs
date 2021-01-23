    public class Notification
    {
        public string send_date { get; set; }
        public bool ignore_user_timezone { get; set; }
        public int platforms { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ios_badges { get; set; }
        public string devices { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string android_header { get; set; }
        public string uuid_list { get; set; }
    }
    
    public class MyMessage
    {
        public string application { get; set; }
        public string auth { get; set; }
        public List<Notification> notifications { get; set; }
    }
    string pwApplication = "XXXXXXXXX";
    bool isAndroid = uuid.DevicePlatform == "android";
    var myNotif =
        new Notification
        {
            send_date = "now",
            ignore_user_timezone = true,
            platforms = isAndroid ? 3 : 1,
            devices = uuid.UuidId
        };
    if (isAndroid)
    {
        myNotif.android_header = "whatever you put here";
    }
    else
    {
        myNotif.ios_badges = totalBadgeCount.BadgeCount;
    }
    myNotif.uuid_list = string.Join(",",
       totalBadgeCount.Uuids.Where(x => x.DevicePlatform == uuid.DevicePlatform)
                            .Select(x => x.UuidId));
    var myMessage = new MyMessage
    {
        application = pwApplication,
        auth = pwAuth,
        notifications = new List<Notification> { myNotif }
    };
    var json = JsonConvert.SerializeObject(myMessage);
    PwCall("createMessage", json);
