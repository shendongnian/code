    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    namespace Core.DataAccess.OleDb
    {
        public static class DataInterface
        {
            public static DataTable DoRead(string connectionString, string commandText)
            {
                return DoRead(connectionString, commandText, new OleDbParameter[] { });
            }
            public static DataTable DoRead(string connectionString, string commandText, OleDbParameter[] parameters)
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbCommand command = new OleDbCommand(commandText, connection);
                foreach (OleDbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                return table;
            }
            public static void DoWrite(string connectionString, string commandText)
            {
                DoWrite(connectionString, commandText, new OleDbParameter[] { });
            }
            public static void DoWrite(string connectionString, string commandText, OleDbParameter[] parameters)
            {
                OleDbConnection connection;
                OleDbTransaction transaction;
                connection = new OleDbConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                OleDbCommand command = new OleDbCommand(commandText, connection);
                foreach (OleDbParameter p in parameters)
                {
                    command.Parameters.Add(p);
                }
                try
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }
                finally
                {
                    transaction.Commit();
                    connection.Close();
                }
            }
            public static OleDbParameter CreateOleDbParameter(string name, OleDbType type, object value)
            {
                OleDbParameter parameter = new OleDbParameter();
                parameter.OleDbType = type;
                parameter.ParameterName = name;
                parameter.Value = value;
                return parameter;
            }
        }
    }
