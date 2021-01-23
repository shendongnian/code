    Dictionary<int, string> dic = new Dictionary<int, string>();
    dic.Add(1, "09:00");
    dic.Add(2, "09:15");
    dic.Add(3, "09:30");
    return Request.CreateResponse(HttpStatusCode.OK, new
    {
        openTimes = dic
        //openTimes = new output() { prop1 = "09:00", prop2 = "09:15"}
    });
