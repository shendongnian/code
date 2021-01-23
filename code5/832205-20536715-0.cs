    private void srptProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        dsSubReport = EngOrdTaskDB.GetEngOrdTaskbyEONum(eonum);
        e.DataSources.Add(new ReportDataSource “dsSubReport”, dsSubReport.Tables[0]));
    }  
