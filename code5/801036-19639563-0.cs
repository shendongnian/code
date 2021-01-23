    string[] parameterNames = new string[] { "Test1", "Test2", "Test3" };
    JArray jarrayObj = new JArray();
    foreach (string parameterName in parameterNames)
    {
        jarrayObj.Add(parameterName);
    }
    string txtBday = "2011-05-06";
    string txtemail = "dude@test.com";
    JObject UpdateAccProfile = new JObject(
                                   new JProperty("_delete", jarrayObj),
                                   new JProperty("birthday", txtBday),
                                   new JProperty("email", txtemail));
    Console.WriteLine(UpdateAccProfile.ToString());
