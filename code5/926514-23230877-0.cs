        int i = 0;
        foreach (var addy in model.Address)
        {
            var countyList = GetCountyList(addy.State);
            string CountyListCount = "CountyList" + i;
            string StateListCount = "StateList" + i;
            ViewData[CountyListCount] = new SelectList(countyList, null, "CountyName",addy.County);
            ViewData[StateListCount] = new SelectList(stateList, "StateAbbr", "StateName", addy.State);
            i++;
        }
