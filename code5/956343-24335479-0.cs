    /// <summary>
    /// Custom implementation of a wrapper to <see cref="DbConnection"/>.
    /// Allows custom behavior at the connection level.
    /// </summary>
    internal class CustomDbConnection : DbConnectionWrapper
    {
        /// <summary>
        /// Opens a database connection with the settings specified by 
        /// the <see cref="P:System.Data.Common.DbConnection.ConnectionString"/>.
        /// </summary>
        public override void Open()
        {
            base.Open();
            //After the connection has been opened, do our logic to prep the connection
            SetContextInfo();
            //...and we do some other stuff not relevant to this discussion
        }
        /// <summary>
        /// Closes the connection to the database. This is the preferred method of closing any open connection.
        /// </summary>
        /// <exception cref="T:System.Data.Common.DbException">
        /// The connection-level error that occurred while opening the connection.
        /// </exception>
        public override void Close()
        {
            //Before closing, we do some cleanup with the connection to make sure we leave it clean
            //   for the next person that might get it....
            base.Close();
        }
        /// <summary>
        /// Attempts to set context_info to the current connection if the user is 
        /// logged in to our application.
        /// </summary>
        private void SetContextInfo()
        {
            //See if a user is logged in
            var user = Thread.CurrentPrincipal as OurCustomUserType;
            //If not, we don't need to do anything - this is probably a very early call in the application
            if (user == null)
                return;
            //Create the ADO.NET command that will call our stored procedure
            var cmd = CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "p_prepare_connection_for_use";
            //Set the parameters based on the currently logged in user
            cmd.CreateParameter("as_session_id", user.SessionID, null, DbType.Guid);
            cmd.CreateParameter("ai_user_sid", user.UserID, null, DbType.Int32);
            //Run the SP
            cmd.ExecuteNonQuery();
        }
