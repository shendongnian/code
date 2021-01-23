    private int getInvItemsCount()
    {
        int recCount = 0;
        const string uri = "http://localhost:28642/api/InventoryItems";
        var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        webRequest.Method = "GET";
        using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
        {
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                Int32.TryParse(s, out recCount);
            }
        }
        return recCount;
    }
    private void GetInvItemsInBlocks()
    {
        Cursor.Current = Cursors.WaitCursor;
        try
        {
            string lastIDFetched = "0";
            const int RECORDS_TO_FETCH = 100;
            int recordsToFetch = getInvItemsCount();
            bool moreRecordsExist = recordsToFetch > 0;
            int totalRecordsFetched = 0;
    
            while (moreRecordsExist)
            {
                string formatargready_uri = string.Format("http://localhost:28642/api/InventoryItems/{0}/{1}", lastIDFetched, RECORDS_TO_FETCH);
                var webRequest = (HttpWebRequest)WebRequest.Create(formatargready_uri);
                webRequest.Method = "GET";
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    if (webResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var reader = new StreamReader(webResponse.GetResponseStream());
                        string s = reader.ReadToEnd();
                        var arr = JsonConvert.DeserializeObject<JArray>(s);
    
                        foreach (JObject obj in arr)
                        {
                            var id = (string)obj["Id"];
                            lastIDFetched = id;
                            int packSize = (Int16)obj["PackSize"];
                            var description = (string)obj["Description"];
                            int dept = (Int16)obj["DeptSubdeptNumber"];
                            int subdept = (Int16)obj["InvSubdepartment"];
                            var vendorId = (string)obj["InventoryName"];
                            var vendorItem = (string)obj["VendorItemId"];
                            var avgCost = (Double)obj["Cost"];
                            var unitList = (Double)obj["ListPrice"];
    
                            inventoryItems.Add(new WebAPIClientUtils.InventoryItem
                            {
                                Id = id,
                                InventoryName = vendorId,
                                UPC_PLU = vendorId,
                                VendorItemId = vendorItem,
                                PackSize = packSize,
                                Description = description,
                                Quantity = 0.0,
                                Cost = avgCost,
                                Margin = (unitList - avgCost),
                                ListPrice = unitList,
                                DeptSubdeptNumber = dept,
                                InvSubdepartment = subdept
                            });
                            if (progressBar1.Value >= 100)
                            {
                                progressBar1.Value = 0;
                            }
                            progressBar1.Value += 1;
                        } // foreach
                    } // if (webResponse.StatusCode == HttpStatusCode.OK)
                } // using HttpWebResponse
                int recordsFetched = WebAPIClientUtils.WriteRecordsToMockDatabase(inventoryItems, hs);
                label1.Text += string.Format("{0} records added to mock database at {1}; ", recordsFetched, DateTime.Now.ToLongTimeString());
                totalRecordsFetched += recordsFetched;
                moreRecordsExist = (recordsToFetch > (totalRecordsFetched+1));
            } // while
            if (inventoryItems.Count > 0)
            {
                dataGridViewGETResults.DataSource = inventoryItems;
            }
        }
        finally
        {
            Cursor.Current = Cursors.Default;
        }
    }
