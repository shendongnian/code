    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Configuration;
    using System.Reflection;
    using MySql.Data.MySqlClient;
    
    namespace DEFINETHENameSpace
    {
        public class MySQLConnector
        {
            private string connString = null;
    
            public string TheConnectionString
            {
                get
                {
                    if (string.IsNullOrEmpty(connString))
                    {
                        //  connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString; 
                        throw new Exception("No Connection String Specified");
                    }
    
                    return connString;
                }
    
                set
                {
                    connString = value;
                }
            }
    
            private Exception errorMessage;
    
            public Exception ErrorMessage
            {
                get
                {
                    return errorMessage;
                }
    
                set
                {
                    errorMessage = value;
                }
            }
    
            #region ExecuteNonQuery
            /// <summary>
            /// THis will execute a non query, such as an insert statement
            /// </summary>
            /// <returns>1 for success, 0 for failed.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public int ExecuteNonQuery(string theSQLStatement)
            {
                int returnValue = 0;
    
                if (!string.IsNullOrEmpty(theSQLStatement))
                {
                    MySqlConnection connection = new MySqlConnection(TheConnectionString);
                    MySqlCommand command = connection.CreateCommand();
    
                    try
                    {
                        command.CommandText = theSQLStatement;
                        connection.Open();
                        command.ExecuteNonQuery();
    
                        //Success
                        returnValue = 1;
                    }
                    catch (Exception ex)
                    {
                        returnValue = 0;
                        throw ex; //ErrorMessage = ex; 
                        // WriteToLog.Execute(ex.Message, EventLogEntryType.Error);
                    }
                    finally
                    {
                        command.Dispose();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
    
                        connection.Dispose();
                    }
                }
    
                return returnValue;
            }
    
            /// <summary>
            /// THis will execute a non query, such as an insert statement
            /// </summary>
            /// <returns>1 for success, 0 for failed.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public int ExecuteNonQuery(string theSQLStatement, List<MySqlParameter> parameters)
            {
                if ((parameters != null) && (parameters.Count > 0))
                {
                    return ExecuteNonQuery(theSQLStatement, parameters.ToArray());
                }
                else
                {
                    return ExecuteNonQuery(theSQLStatement);
                }
            }
    
            /// <summary>
            /// THis will execute a non query, such as an insert statement
            /// </summary>
            /// <returns>1 for success, 0 for failed.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public int ExecuteNonQuery(string theSQLStatement, MySqlParameter[] parameters)
            {
                if ((parameters == null) || (parameters.Count() <= 0))
                {
                    return ExecuteNonQuery(theSQLStatement);
                }
    
                int returnValue = 0;
    
                if (!string.IsNullOrEmpty(theSQLStatement))
                {
                    MySqlConnection connection = new MySqlConnection(TheConnectionString);
                    MySqlCommand command = connection.CreateCommand();
    
                    try
                    {
                        command.CommandText = theSQLStatement;
                        command.Parameters.AddRange(parameters);
                        connection.Open();
                        command.ExecuteNonQuery();
    
                        //Success
                        returnValue = 1;
                    }
                    catch (Exception ex)
                    {
                        returnValue = 0;
                        throw ex; //ErrorMessage = ex; 
                        //WriteToLog.Execute(ex.Message, EventLogEntryType.Error);
                    }
                    finally
                    {
                        command.Dispose();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
    
                        connection.Dispose();
                    }
                }
    
                return returnValue;
            }
    
            #endregion
    
            #region Execute
            /// <summary>
            /// THis will execute a query, such as an select statement
            /// </summary>
            /// <returns>Populated Datatable based on the sql select command.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public DataTable Execute(string theSQLStatement)
            {
                DataTable resultingDataTable = new DataTable();
    
                if (!string.IsNullOrEmpty(theSQLStatement))
                {
                    MySqlConnection connection = new MySqlConnection(TheConnectionString);
                    MySqlCommand command = connection.CreateCommand();
    
                    try
                    {
                        command.CommandText = theSQLStatement;
                        connection.Open();
    
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command.CommandText, connection);
                        dataAdapter.Fill(resultingDataTable);
    
                        //Success
                    }
                    catch (Exception ex)
                    {
                        throw ex; //ErrorMessage = ex; 
    
                        //WriteToLog.Execute(ex.Message, EventLogEntryType.Error);
                    }
                    finally
                    {
                        command.Dispose();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
    
                        connection.Dispose();
                    }
                }
    
                return resultingDataTable;
            }
    
            /// <summary>
            /// THis will execute a query, such as an select statement
            /// </summary>
            /// <returns>Populated Datatable based on the sql select command.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public DataTable Execute(string theSQLStatement, List<MySqlParameter> parameters)
            {
    
                if ((parameters != null) && (parameters.Count > 0))
                {
                    return Execute(theSQLStatement, parameters.ToArray());
                }
                else
                {
                    return Execute(theSQLStatement);
                }
            }
    
            /// <summary>
            /// THis will execute a query, such as an select statement
            /// </summary>
            /// <returns>Populated Datatable based on the sql select command.</returns>
            /// <author>James 'Gates' R.</author>
            /// <createdate>8/20/2012</createdate>
            public DataTable Execute(string theSQLStatement, MySqlParameter[] parameters)
            {
                if ((parameters == null) || (parameters.Count() <= 0))
                {
                    return Execute(theSQLStatement);
                }
    
                DataTable resultingDataTable = new DataTable();
    
                if (!string.IsNullOrEmpty(theSQLStatement))
                {
                    MySqlConnection connection = new MySqlConnection(TheConnectionString);
                    MySqlCommand command = connection.CreateCommand();
    
                    try
                    {
                        command.CommandText = theSQLStatement;
                        connection.Open();
    
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command.CommandText, connection);
                        dataAdapter.SelectCommand.Parameters.AddRange(parameters);
                        dataAdapter.Fill(resultingDataTable);
    
                        //Success
                    }
                    catch (Exception ex)
                    {
                        throw ex; //ErrorMessage = ex; 
                        //WriteToLog.Execute(ex.Message, EventLogEntryType.Error);
                    }
                    finally
                    {
                        command.Dispose();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
    
                        connection.Dispose();
                    }
                }
    
                return resultingDataTable;
            }
        }
            #endregion
    }
