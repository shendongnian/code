            public string GetMediaId(TinyTwitter twit, string file)
        {
            byte[] files = System.IO.File.ReadAllBytes(file);
            string Base64File = Convert.ToBase64String(files);
            string response = twit.UpdateMedia(Base64File);
            JObject j = JObject.Parse(response);
            return Convert.ToString(j["media_id"]);
        }
