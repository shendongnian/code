    do
    {
        redemptionsList.redemptions.Clear();
        string uri = String.Format("http://platypus:28642/api/Redemptions/{0}/{1}",     lastIdFetched, RECORDS_TO_FETCH);
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        webRequest.Method = "GET";
        using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
        {
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                var arr = JsonConvert.DeserializeObject<JArray>(s);
                if (arr == null) break;
                foreach (JObject obj in arr)
                {
                    id = obj.Value<int?>("Id") ?? 0;
                    var _redemptionId = obj.Value<string>("RedemptionId") ?? "";
                    var _redemptionItemId = obj.Value<string>("RedemptionItemId") ?? "";
                    var _redemptionName = obj.Value<string>("RedemptionName") ?? "";
                    double _redemptionAmount = obj.Value<double?>("RedemptionAmount") ?? 0.0;    
                    var _redemptionDept = obj.Value<string>("RedemptionDept") ?? "";
                    var _redemptionSubdept = obj.Value<string>("RedemptionSubDept") ?? "";
                    redemptionsList.redemptions.Add(new HHSUtils.Redemption
                    {
                        Id = id,
                        RedemptionId = _redemptionId,
                        RedemptionItemId = _redemptionItemId,
                        RedemptionName = _redemptionName,
                        RedemptionAmount = _redemptionAmount,
                        RedemptionDept = _redemptionDept,
                        RedemptionSubDept = _redemptionSubdept,
                    });
                } // foreach
            } // if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 2))
        } // using HttpWebResponse
        int recordsAdded = LocalDBUtils.BulkInsertRedemptions(redemptionsList.redemptions);
        totalRecordsAdded += recordsAdded;
        moreRecordsExist = (recordsToFetch > (totalRecordsAdded));
        lastIdFetched = id;
    } while (moreRecordsExist);
