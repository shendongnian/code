    SortedDictionary<string, string> objDic = new SortedDictionary<string, string>();
                foreach (CultureInfo ObjectCultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    RegionInfo objRegionInfo = new RegionInfo(ObjectCultureInfo.Name);
                    if (!objDic.ContainsKey(objRegionInfo.EnglishName))
                    {
                        objDic.Add(objRegionInfo.EnglishName, ObjectCultureInfo.Name);
                    }
                }
    
                foreach (KeyValuePair<string, string> val in objDic)
                {
                    country.Items.Add(new ListItem(val.Key, val.Value));//country is dropdownlist name..
                }
