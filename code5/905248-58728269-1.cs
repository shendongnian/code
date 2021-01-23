    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Dynamic;
    using Newtonsoft.Json;
    
    // microsoft sqlserver
    using System.Data.SqlClient;
    // oracle
    using Oracle.ManagedDataAccess.Client;
    
    namespace InqdWeb
    {
      public class Dbio
      {
        //
        public static class Consts
        {
          public const string msgname = "retmsg";
          public const string valname = "retval";
          public const string jsond = "{ }";
          public const string jsonr = "{ \"" + msgname + "\":  \"OK\" }";
        }
        //
        //
        // »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
        // core functions
        // »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
        // 
        //
        //  with  a "sql statement" 
        //    and a connection id, 
        //  prepare the actual sql to get data
        //  return the result as json 
        public static string sqljson
          (string pi_sql
            , string pi_conn
          )
        {
            // empty data
            var vd = Consts.jsond;
            // success message
            var vr = Consts.jsonr;
            string msgout = "00";
            var ld = new List<dynamic>();
            ld = sqlmaster(pi_sql, pi_conn, out msgout);
            //      
            if (msgout.Substring(0, 2) == "00")    // not empty and no errors 
            {
                vd = JsonConvert.SerializeObject(ld);
                vr = Consts.jsonr.Replace("OK", "00");
            }
            if (msgout.Substring(0, 2) == "10")    //      empty and no errors 
            {
                vr = Consts.jsonr.Replace("OK", "10");
            }
            if (msgout.Substring(1, 1) == "1")    //      error 
            {
                vd = JsonConvert.SerializeObject(ld);
                vr = Consts.jsonr.Replace("OK", msgout);
            }
            // return json with 2 collections: d with data, r with status and message
            var vt = jsonmerge(vd, vr);
            return vt;
        }
        //
        //
        //
        //  with  a sql 
        //    and a conn id
        //  return data as dynamic list
        public static List<dynamic> sqlmaster
          (string pi_sql
            , string pi_conn
            , out string po_msg
          )
        {
            string sql = " ";
            sql = pi_sql;
            // result 
            po_msg = msgout;
            // po_msg     pos1      empty: 1    has rows: 0
            //            pos2      error: >0   no error: 0
            //            pos3...   error message
            return lista;
        }
        //
        //
        //  with    a sql statement 
        //      and a connection string
        //  return the result on a dynamic list
        //  plus a string with
        //        pos1    error         0-ok  1-error
        //        pos2    list empty    0-ok  1-list is empty
        //        pos3... message       return code from non-select  or error message
        public static List<dynamic> sqldo
          (string pi_sql
            , string pi_connstring
            , out string msgout
          )
        {
          // variables
          string sql = pi_sql;
          var lista = new List<dynamic>();
          int retcode;
          msgout = "0";
          // 
          string ConnString = pi_connstring;
          //      
          //
          // 
          // Microsoft SqlServer
          if (SqlFlavor == "Ms")
          {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
              try
              {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                if (sqltype == "R")
                {
                  SqlDataReader reada = cmd.ExecuteReader();
                  string datatype = "-";
                  string colname = "-";
                  while (reada.Read())
                  {
                    var obj = new ExpandoObject();
                    var d = obj as IDictionary<String, object>;
                    // 
                    for (int index = 0; index < reada.FieldCount; index++)
                    {
                      datatype = reada.GetDataTypeName(index);
                      colname = reada.GetName(index);
                      bool isnul = reada.IsDBNull(index);
                      if (!isnul)
                      {
                        // add datatypes as needed 
                        switch (datatype)
                        {
                          case "int":
                            d[colname] = reada.GetValue(index);
                            break;
                          case "varchar":
                            d[colname] = reada.GetString(index);
                            break;
                          case "nvarchar":
                            d[colname] = reada.GetString(index);
                            break;
                          case "date":
                            d[colname] = reada.GetDateTime(index);
                            break;
                          default:
                            d[colname] = reada.GetString(index);
                            break;
                        }
                      }
                      else
                      {
                        d[colname] = "";
                      }
                    }
                    lista.Add(obj);
                  }
                  reada.Close();
                }
              }
              catch (Exception ex)
              {
                msgout = "11" + ex.Message.ToString();
              }
            }
          }
          // 
          // Oracle
          if (SqlFlavor == "Oa")
          {
            // Or uses a "
            sql = sql.Replace("[", "\"");
            sql = sql.Replace("]", "\"");
            using (OracleConnection con = new OracleConnection(ConnString))
            {
              try
              {
                con.Open();
                //
                OracleCommand cmd = new OracleCommand(sql, con);
                  OracleDataReader reada = cmd.ExecuteReader();
                  string datatype = "-";
                  string colname = "-";
                  while (reada.Read())
                  {
                    var obj = new ExpandoObject();
                    var d = obj as IDictionary<String, object>;
                    // browse every column
                    for (int index = 0; index < reada.FieldCount; index++)
                    {
                      datatype = reada.GetDataTypeName(index);
                      colname = reada.GetName(index);
                      bool isnul = reada.IsDBNull(index);
                      if (!isnul)
                      {
    										// add datatypes as needed 
                        switch (datatype)
                        {
                          case "Decimal":
                            d[colname] = reada.GetValue(index);
                            break;
                          case "Varchar":
                            d[colname] = reada.GetString(index);
                            break;
                          default:
                            d[colname] = reada.GetString(index);
                            break;
                        }
                      }
                      else
                      {
                        d[colname] = "";
                      }
                    }
                    lista.Add(obj);
                  }
                  reada.Close();
                // 
              }
              catch (Exception ex)
              {
                msgout = "11" + ex.Message.ToString();
              }
            }
          }
          // 
          //
          //
          return lista;
        }
        //
        //
    }
    
