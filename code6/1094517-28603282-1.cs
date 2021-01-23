    var indlist = db.IND_TABLE
                    .Where(x => x.Package_No.Trim() != "");
    
    string[] strValue = filter_Values;
    foreach (SelectedData selectedData in objSelectedDataCollection.DataCollection)
    {
        switch (selectedData.ColumnName)
        {
            case "Outlook":
                indlist = indlist.Where(il => il.IND_APP_PASS_STATUS(iaps => strValue.Contains(iaps.Outlook)));
                break;
            case "RS_TP":
                indlist = indlist.Where(il => il.IND_APP_PASS_STATUS(iaps => strValue.Contains(iaps.RS_TP)));
                break;
            case "Code":
                indlist = indlist.Where(il => il.IND_APP_PASS_STATUS(iaps => strValue.Contains(iaps.Code)));
                break;
        }
    }
    
    indlist = indlist.OrderBy(x => x.Indman_ID).ToList();
