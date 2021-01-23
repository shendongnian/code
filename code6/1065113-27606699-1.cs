    public partial class SELECT_CONFIGURATIONResponse
    {
         public string ReturnValue { get; set; }
         public SELECT_CONFIGURATIONResponseStoredProcedureResultSet0 StoredProcedureResultSet0 { get; set; }
    }
    public partial class SELECT_CONFIGURATIONResponseStoredProcedureResultSet0
    {
        public StoredProcedureResultSet0 StoredProcedureResultSet0[] { get; set }
    }
    public partial class StoredProcedureResultSet0
    {
        public string FlowId { get; set; }
        // Etc etc
    }
