    public void TransactionQuery(ArrayList list)
        {
            try
            {
                foreach (MySqlCommand command in list)
                {
                    //Console.WriteLine(command.CommandText);
                    command.Connection = this._connection;
                    command.CommandType = CommandType.Text;
                    command.Transaction = this._transaction;
                    command.ExecuteNonQuery();
                }
                this._transaction.Commit(); 
            }
            catch (MySqlException ex)
            {
                this._transaction.Rollback();
                throw new MySQLException(ex.Message, ex.Number);
            }
        }
