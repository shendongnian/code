         class Temp1
         {
            private string _DocumentID;
            private string _DocumentName;
    
            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DocumentID", DbType = "NVarChar(256)")]
            string DocumentID
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
            string DocumentName
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
    
        class Temp2
        {
            private string _DocumentID ;
    
            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DocumentID ", DbType = "NVARCHAR(256)")]
            string DocumentID 
            {
                get
                {
                    return this._DocumentID ;
                }
                set
                {
                    if ((this._DocumentID != value))
                    {
                        this._DocumentID = value;
                    }
                }
            }
        }
    
        class Temp3
        {
            private string _DocumentID;
    
            [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DocumentID", DbType = "NVarChar(256)")]
            string DocumentID
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
        }
