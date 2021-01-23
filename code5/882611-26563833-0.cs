    string jsonString = httpResponseMessage.Content.ReadAsStringAsync()
                                                   .Result
                                                   .Replace("\\", "")
                                                   .Trim(new char[1] { '"' });
    
    List<VwAisItemMaster> vwAisItemMasterList = JsonConvert.DeserializeObject<List<VwAisItemMaster>>(jsonString);
