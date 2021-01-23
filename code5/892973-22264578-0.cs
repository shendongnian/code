    dynamic wrkCacheTableObject = wrkTablePropInfo.GetValue(wrkGSD, null);
    //--- get the row using dynamic
    dynamic wrkRow = wrkCacheTableObject[(long)varAJR.rowID];
    //--- put the row back
    wrkCacheTableObject[(long)varAJR.rowID]= wrkRow;
