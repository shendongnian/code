        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Data;
        using System.Data.Common;
        using Oracle.DataAccess.Types;
        using Oracle.DataAccess.Client;
        namespace Data
        {
           public class Data
            {
                public  OracleConnection GetConnection()
                {
                    string connection = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
                    return new OracleConnection(connection);
                }
                public DataTable ExecuteCmd()
                {
                    OracleConnection cn = new OracleConnection();
                    OracleCommand dbCommand = cn.CreateCommand();
                    DataTable oDt = new DataTable();
                    cn = GetConnection();
                    dbCommand.CommandText = "pckClient.spr_Client";
                    dbCommand.CommandType = CommandType.StoredProcedure;
            
                    try
                    {
                        dbCommand.Connection = cn;
                        dbCommand.Parameters.Add(new OracleParameter("cCursorData", 
                        OracleDbType.RefCursor, ParameterDirection.Output));
                        OracleDataAdapter oDa = new OracleDataAdapter(dbCommand);
                        oDa.Fill(oDt);
                        return oDt;
                
                    }
                    catch (Exception ex)
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                        dbCommand.Dispose();
                        cn.Dispose();
                        throw ex;
               
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                        dbCommand.Dispose();
                        cn.Dispose();
                    }
                }
            }
        }
