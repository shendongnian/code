    string pwApplication = "XXXXXXXXX";
    bool isAndroid = uuid.DevicePlatform == "android";
    var myNotif = new JObject(
                    new JProperty("send_date", "now"),
                    new JProperty("ignore_user_timezone", true),
                    new JProperty("platforms", isAndroid ? 3 : 1),
                    new JProperty("devices", uuid.UuidId)
                    );
    if (isAndroid)
    {
        myNotif.Add(new JProperty("android_header", "whatever you put here"));
    }
    else
    {
        myNotif.Add(new JProperty("ios_badges", totalBadgeCount.BadgeCount));
    }
    myNotif.Add(new JProperty("uuid_list", string.Join(",",
       totalBadgeCount.Uuids.Where(x => x.DevicePlatform == uuid.DevicePlatform)
                            .Select(x => x.UuidId))));
    var json = new JObject(
        new JProperty("application", pwApplication),
        new JProperty("auth", pwAuth),
        new JProperty("notifications",
            new JArray(myNotif)));
    PwCall("createMessage", json);
