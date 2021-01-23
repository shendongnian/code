       var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            List<JToken> results = new List<JToken>();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                results = JObject.Parse(result).SelectToken("record").ToList();
            }
            List<Role> roles = new List<Role>();
            foreach(JObject token in results)
            {
                Role role = new Role();
                role.Id = Int32.Parse(token["id"].ToString());
                role.RoleName = token.SelectToken("name").ToString();
                roles.Add(role);
            }
            return roles;
