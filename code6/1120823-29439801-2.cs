    HttpResponseMessage memberResponse = await client.GetAsync("api/Members?MemberStr=" + currUser);
    if(memberResponse.StatusCode == HttpStatusCode.OK)
    {
        // got the memberId...
        var memberId = Convert.ToInt32( memberResponse.Content.ReadAsStringAsync().Result);
    }
    else if(memberResponse.StatusCode == HttpStatusCode.NotFound)
    {
        // member not found...
    }
