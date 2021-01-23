    CrystalDecisions.ReportAppServer.DataDefModel.Table boTable = new CrystalDecisions.ReportAppServer.DataDefModel.Table();
    CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag boMainPropertyBag = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
    CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag boInnerPropertyBag = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
    
    // Custom function to fill property bags with values which influence the table properties as seen in CR Developer
    FillPropertyBags(boMainPropertyBag, boInnerPropertyBag);
    
    CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo boConnectionInfo = new CrystalDecisions.ReportAppServer.DataDefModel.ConnectionInfo();
    boConnectionInfo.Attributes = boMainPropertyBag;
    boConnectionInfo.Kind = CrystalDecisions.ReportAppServer.DataDefModel.CrConnectionInfoKindEnum.crConnectionInfoKindCRQE;
    
    boTable.ConnectionInfo = boConnectionInfo;
    
    CrystalDecisions.ReportAppServer.DataDefModel.Tables boTables = boReportDocument.ReportClientDocument.DatabaseController.Database.Tables;
    
    for (int i = 0; i < boTables.Count; i++)
    {
       boTable.Name = boTables[i].Name;
       // the QualifiedName is directly taken into the CR general query so this is a quick fix to change it
       boTable.QualifiedName = boTables[i].QualifiedName.Replace("oldDbName", "newDbName"); 
       boTable.Alias = boTables[i].Alias;
       boReportDocument.ReportClientDocument.DatabaseController.SetTableLocation(boTables[i], boTable);
    }
