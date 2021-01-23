    public void Query(MySqlCommand command)
        {
            var transaction = this._connection.BeginTransaction("SampleTransaction");
            try
            {
                command.Connection = this._connection;
                command.CommandType = CommandType.Text;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (MySqlException ex)
            {
                transaction.Rollback();
                throw new MySQLException(ex.Message, ex.Number);
            }
        }
