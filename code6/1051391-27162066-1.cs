    using System;
    using System.IO;
    using System.Web;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    
    public class SaveWidgets : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) 
        {
            String json = String.Empty;
            // you have sent JSON to the server
            // read it into a string via the input stream
            using (StreamReader rd = new StreamReader(context.Request.InputStream))
            {
                json = rd.ReadToEnd();
            }
    
            // create an instance of YourDataModel from the
            // json sent to this handler
            YourDataModel data = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(YourDataModel));
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] utf8Bytes = Encoding.UTF8.GetBytes(json);
                ms.Write(utf8Bytes, 0, utf8Bytes.Length);
                ms.Position = 0;
                data = serializer.ReadObject(ms) as YourDataModel;
            }
    
            // update the DB and
            // send back a JSON response
            int rowsUpdated = 0;
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["dboCao"].ConnectionString))
            {
                c.Open();
                
                String sql = @"
                    INSERT INTO TestTable 
                        (Column1, Column2) 
                      VALUES 
                        (@column1, @column2);";
                
                using (SqlCommand cmd = new SqlCommand(sql, c))
                {
                    cmd.Parameters.Add("@column1", SqlDbType.VarChar, 50).Value = data.Col1;
                    cmd.Parameters.Add("@column2", SqlDbType.VarChar, 50).Value = data.Column2;
                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }
    
            context.Response.ContentType = "application/json";
            context.Response.Write("{ \"rows_updated\": " + rowsUpdated + " }");
        }
     
        public bool IsReusable {
            get { return false; }
        }
    }
