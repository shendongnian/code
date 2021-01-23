        JArray array = new JArray();
        foreach (User user in users)
        {
            JObject userObj = new JObject();
            userObj.Add("Id1", user.Id1);
            userObj.Add("Id2", user.Id2);
            array.Add(userObj);
        }
        JObject result = new JObject();
        result.Add("Users", array);
