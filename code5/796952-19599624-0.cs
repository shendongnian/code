        /// <summary>
        /// Create a package with a data flow that pulls from table src_dWolf
        /// <example>
        /// CREATE TABLE dbo.src_dWolf
        /// (
        ///     le_key int NOT NULL PRIMARY KEY
        /// ,   le_value varchar(50) NOT NULL  
        /// );
        ///
        /// CREATE TABLE dbo.dst_dWolf
        /// (
        ///     le_key int NOT NULL PRIMARY KEY
        /// ,   le_value varchar(50) NOT NULL  
        /// ,   le_newValue varchar(20) NOT NULL
        /// );
        /// 
        /// INSERT INTO dbo.src_dWolf
        /// (
        ///     le_key
        /// ,   le_value
        /// )
        /// VALUES
        /// (
        ///     10
        /// ,   'ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTU'
        /// );
        /// </example>
        /// </summary>
        public static void Demo()
        {
            string dataVault_ConMgr = @"Data Source=localhost\DEV2012;Provider=SQLNCLI10.1;Integrated Security=SSPI;Initial Catalog=TypeMoreClickLess;";
            EzPackage package = new EzPackage();
            string stgTable = "src_dWolf";
            string bd_datavault_schema_staging = "dbo";
            string ssis_prefix_dataflow_oledb_source = "SRC ";
            string ssis_prefix_task_derived = "DST ";
            EzDataFlow satelliteDft = new EzDataFlow(package);
            satelliteDft.Name = "DFT demo";
            EzSqlOleDbCM RefConn = new EzSqlOleDbCM(package, dataVault_ConMgr);
            RefConn.Name = "TMCL";
            RefConn.ConnectionString = dataVault_ConMgr;
            EzOleDbSource ezOleDbSource_SatFromStaging = new EzOleDbSource(satelliteDft);
            ezOleDbSource_SatFromStaging.Table = String.Format("[{0}].[{1}]", bd_datavault_schema_staging, stgTable);
            ezOleDbSource_SatFromStaging.Name = ssis_prefix_dataflow_oledb_source + stgTable;
            ezOleDbSource_SatFromStaging.Connection = RefConn;
            EzDerivedColumn ezDerivedColumn = new EzDerivedColumn(satelliteDft);
            ezDerivedColumn.Name = ssis_prefix_task_derived + stgTable;
            ezDerivedColumn.InsertOutputColumn("le_newValue");
            ezDerivedColumn.SetOutputColumnDataTypeProperties("le_newValue", Microsoft.SqlServer.Dts.Runtime.Wrapper.DataType.DT_STR, 20, 0, 0, 1252);
            // http://social.msdn.microsoft.com/Forums/sqlserver/en-US/137af5f4-3d35-45c2-9a3f-2127dc98fb6c/ezapi-how-to-working-with-ezderivedcolumn?forum=sqlintegrationservices
            Microsoft.SqlServer.Dts.Pipeline.Wrapper.IDTSOutputColumn100 derCol = ezDerivedColumn.OutputCol("le_newValue");
            derCol.CustomPropertyCollection["FriendlyExpression"].Value = "SUBSTRING([le_value], 1, 20 )";
            derCol.CustomPropertyCollection["Expression"].Value = "SUBSTRING([le_value], 1, 20 )";
            ezDerivedColumn.AttachTo(ezOleDbSource_SatFromStaging);
            EzOleDbDestination ezOleDbDestination = new EzOleDbDestination(satelliteDft);
            ezOleDbDestination.Name = "DST dst_dWolf";
            ezOleDbDestination.Table = "[dbo].[dst_dWolf]";
            ezOleDbDestination.Connection = RefConn;
            ezOleDbDestination.FastLoadKeepIdentity = true;
            ezOleDbDestination.FastLoadKeepNulls = true;
            ezOleDbDestination.FastLoadOptions = "TABLOCK,CHECK_CONSTRAINTS";
            ezOleDbDestination.AccessMode = AccessMode.AM_OPENROWSET_FASTLOAD;
            ezOleDbDestination.AttachTo(ezDerivedColumn);
            ezOleDbDestination.LinkAllInputsToOutputs();
            package.SaveToFile(@"C:\sandbox\TypeMoreClickLess\EzAPIDemo\dwolf.dtsx");
        }
