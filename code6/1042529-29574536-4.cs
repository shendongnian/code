     public static async Task<T> GetAsync<T>(Facebook.FacebookClient facebookClient, string objectPath, bool AddGetFields = true)
            where T: class
        {
           var path = objectPath + (AddGetFields ? FacebookQueryHelper.GetFields(typeof(T)) : "");
            dynamic response = await facebookClient.GetTaskAsync(path);
            var str = response.ToString() as string;
            if (str.IsNullOfEmpty())
                return default(T);
            return await Newtonsoft.Json.JsonConvert.DeserializeObjectAsync<T>(str);
        }
      public static Task<MyAppUser> GetCurrentLogedUser(Facebook.FacebookClient facebookClient)
        {
            return GetAsync<MyAppUser>(facebookClient, "/me");
        }
