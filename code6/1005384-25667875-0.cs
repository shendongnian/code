    var iCountParam = new ObjectParameter("iCount", typeof(int));
    var iTotalCountParam = new ObjectParameter("iTotalCount", typeof(int));
    var xmlResultsParam = new ObjectParameter("xmlResults", typeof(string));
    var dtLastItemModifiedParam = new ObjectParameter("dtLastItemModified", typeof(DateTime));
    
    var search_results = db.spVehicleSearch(strLocale, xmlSearchCriteria, strSortBy, strSortDir, uidSessionId, iPage, iPageSize, iCountParam, iTotalCountParam, bShowResults, xmlResultsParam, dtLastItemModifiedParam, uidVehicleInList);
    //using your previously declared variables...
    iCount = (int)iCountParam.Value;
    iTotalCount = (int)iTotalCountParam.Value;
    //since these are nullable params, gotta check before casting
    //you can obviously use whatever you want for the value if it is indeed null
    xmlResults = Convert.IsDBNull(xmlResultsParam.Value) ? null : (string)xmlResultsParam.Value;
    dtLastItemModified = Convert.IsDBNull(dtLastItemModifiedParam.Value) ? DateTime.MinValue : (DateTime)dtLastItemModifiedParam.Value;
