    HttpCookie cookies = new HttpCookie("QuickJumpCookie");
    var serializer = new JavaScriptSerializer();
    var serializedResult = serializer.Serialize(bal.GetMeetingList(personID, "Open"));
    cookies["MeetingList"] = serializedResult;
    Response.Cookies.Add(cookies);
    HttpCookie cookies = Request.Cookies["QuickJumpCookie"];
    MeetingList ml = serializer.Deserialize<MeetingList>(cookies["MeetingList"]);
