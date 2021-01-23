    public class TerrasoftFiles : ITerrasoftFiles
    {
        public TerrasoftFiles()
        {
            this.sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TTDataReader"].ConnectionString);
            this.sqlCommand = new SqlCommand(@"SELECT FileData FROM tbl_Files WHERE ID = @ID", sqlConnection);
        }
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        public IAsyncResult BeginGetFiles(Guid ID, AsyncCallback asyncCallBack, object asyncState)
        {
            sqlCommand.Parameters.Add(new SqlParameter("@ID", ID));
            sqlConnection.Open();
            return sqlCommand.BeginExecuteReader(asyncCallBack, asyncState);
        }
        public Stream EndGetFiles(IAsyncResult asyncResult)
        {
            using(sqlConnection as IDisposable)
               using (sqlCommand as IDisposable)
                    using (var Reader = sqlCommand.EndExecuteReader(asyncResult))
                    {
                        return (Reader.Read()) ? Reader.GetSqlBytes(0).Stream : Stream.Null;
                    }
        }
    }
