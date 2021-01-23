    // CMyDynaset.cs
    using System;
    using System.Data.Common;
    namespace MyDb
    {
	    /// <summary>
	    /// Summary description for CMyDynaset.
	    /// </summary>
	    public class CMyDynaset : IDisposable
	    {
		    public System.Data.DataTable Table = null;
		    // private
            private DbConnection myConnection = null;
            private DbProviderFactory myFactory = null;
            private DbDataAdapter dataAdap = null;
		    private DbCommandBuilder cmdBld = null;
            private bool bIsSchema = false;
            public CMyDynaset(DbConnection conn, DbProviderFactory factory)
		    {
                this.myConnection = conn;
                this.myFactory = factory;
		    }
            #region IDisposable Members
            public void Dispose()
            {
                if (this.Table != null)
                {
                    this.Table.Dispose();
                    this.Table = null;
                }
                if (this.cmdBld != null)
                {
                    this.cmdBld.Dispose();
                    this.cmdBld = null;
                }
                if (this.dataAdap != null)
                {
                    this.dataAdap.Dispose();
                    this.dataAdap = null;
                }
                // This object will be cleaned up by the Dispose method.
                // Therefore, you should call GC.SupressFinalize to
                // take this object off the finalization queue
                // and prevent finalization code for this object
                // from executing a second time.
                GC.SuppressFinalize(this);
            }
            #endregion
		    // Init
            public void Init(string strSelect)
		    {
                DbCommand cmdSel = this.myConnection.CreateCommand();
                cmdSel.CommandText = strSelect;
            
                this.dataAdap = this.myFactory.CreateDataAdapter();
                this.dataAdap.SelectCommand = cmdSel;
                this.cmdBld = this.myFactory.CreateCommandBuilder();
                this.cmdBld.DataAdapter = this.dataAdap;
                this.Table = new System.Data.DataTable();
                // schema
                this.bIsSchema = false;
		    }
            public void AddParameter(string name, object value)
            {
                DbParameter param = this.dataAdap.SelectCommand.CreateParameter();
                param.ParameterName = name;
                param.Value = value;
                this.dataAdap.SelectCommand.Parameters.Add(param);
            }
            public void AddParameter(DbParameter param)
            {
                this.dataAdap.SelectCommand.Parameters.Add(param);
            }
		    // Open, Close
		    private void Open(ref bool bClose)
		    {
                if (this.myConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.myConnection.Open();
                    bClose = true;
                }
                if (!this.bIsSchema)
                {   // schema
                    this.dataAdap.FillSchema(this.Table, System.Data.SchemaType.Mapped);
                    this.bIsSchema = true;
                }
		    }
		
		    private void Close(bool bClose)
		    {
			    if (bClose)
                    this.myConnection.Close();
		    }
            // Load, Update
		    public void Load()
		    {
			    bool bClose = false;
			    try
			    {
                    this.Table.Clear();
				    this.Open(ref bClose);
				    this.dataAdap.Fill(this.Table);
			    }
			    catch (System.Exception ex) 
			    {
				    throw ex;
			    }
			    finally
			    {
				    this.Close(bClose);
			    }
		    }
		    public void Update()
		    {
			    bool bClose = false;
			    try
			    {
                    this.Open(ref bClose);
                    this.dataAdap.Update(this.Table);
			    }
			    catch (System.Exception ex) 
			    {
				    throw ex;
			    }
			    finally
			    {
				    this.Close(bClose);
			    }
		    }
	    }
    }
