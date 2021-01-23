    global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DemoSP")]
    		public ISingleResult<DemoSPResult> DemoSP()
    		{
    			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
    			return ((ISingleResult<DemoSPResult>)(result.ReturnValue));
    		}
         public partial class DemoSPResult
         {
            private string _DocumentID;
            private string _DocumentName;
            public DemoSPResult()
            {
            }
    
            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DocumentID", DbType = "NVarChar(256)")]
            public string DocumentID
            {
                get
                {
                    return this._DocumentID;
                }
                set
                {
                    if ((this._DocumentID != value))
                    {
                        this._DocumentID = value;
                    }
                }
            }
    
            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DocumentName", DbType = "VarChar(100)")]
            public string DocumentName
            {
                get
                {
                    return this._DocumentName;
                }
                set
                {
                    if ((this._DocumentName != value))
                    {
                        this._DocumentName = value;
                    }
                }
            }
        }
