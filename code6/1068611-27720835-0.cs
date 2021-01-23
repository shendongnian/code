    /*
    App_Code/MyDictionary.cs
    */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    using System.Data.OleDb;
    using System.Configuration;
    
    /// <summary>
    /// Summary description for MyDictionary
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class MyDictionary : System.Web.Services.WebService {
    
        public MyDictionary() {
    
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
    
        [ScriptMethod()]
        [WebMethod]
        //removed static modifier
        //display error: Unknown web method searchInDictionary.
        public List<string> searchInDictionary(string prefixText, int count)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["myConnectionString"].ConnectionString;
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "SELECT word FROM Dictionary WHERE word LIKE @prefixText";
                    cmd.Parameters.AddWithValue("@prefixText", prefixText + "%");
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> result = new List<string>();
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.Add(dr["word"].ToString());
                        }
                    }
                    conn.Close();
                    return result;
                }
            }
        }
    }
