    public QueryResult{
      public DataTable Data{get;set;}
      public bool Error{get;set;}
      public string ErrorMessage{get;set;}
    }
    public QueryResult PapoulateIndexAnalyssList()
    {
        var result = new QueryResult();
        result.Data = new DataTable();
        try
        {
            this.indiceTableAdapter.FillBy(this.ds_IndexAnalysis.Indice);
            result.Data = this.tmp_Table_Analisi_IndexTableAdapter.GetData();
        }
        catch(Exception ex)
        {
            //Logging Error:
            errorMessageVieReportDAL = ex.Message;
            Logs.WriteLog(errorMessageVieReportDAL);
            ObjResults.SetFailure = false;
            ObjResults.GetErrorMessage = errorMessageVieReportDAL;
            result.Error = true;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
