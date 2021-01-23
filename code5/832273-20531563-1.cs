    using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
    {
        if (webResponse.StatusCode == HttpStatusCode.OK)
        {
            var reader = new StreamReader(webResponse.GetResponseStream());
            string jsonizedRedemptions = reader.ReadToEnd();
            List<Redemption> redemptions = JsonConvert.DeserializeObject<List<Redemption>>(jsonizedRedemptions);
            if (arr.Count <= 0) break;
            foreach (Redemption redemption in redemptions)
            {
                redemptionsList.redemptions.Add(redemption);
            }
        } // if ((webResponse.StatusCode == HttpStatusCode.OK)
    } // using HttpWebResponse
