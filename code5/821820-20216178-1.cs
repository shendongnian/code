    using System.Data;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Configuration;
    [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCountries(string prefixText)
        {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Country where CountryName like @Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> CountryNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
        CountryNames.Add(dt.Rows[i][1].ToString());
        }
        return CountryNames;
        }
