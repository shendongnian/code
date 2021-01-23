    using System;
    using System.Web;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Text;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace PlatForm_RollUp
    {
        /// <summary>
        /// Summary description for SearchDPN
        /// </summary>
        public class SearchDPN : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                string prefixText = context.Request.QueryString["term"];
                if (string.IsNullOrEmpty(prefixText)) { prefixText = "NA"; }
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["PPN_ConnectionString"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select DPN_Key, DPN, Item_Desc from Customer.DIM.PPN WHERE " +
                            "DPN like @SearchText+'%'";
                        cmd.Parameters.AddWithValue("@SearchText", prefixText);
                        cmd.Connection = conn;
                        //StringBuilder sb = new StringBuilder();
                        List<string> _dpn = new List<string>();
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                //sb.Append(string.Format("{0} - {1}", sdr["DPN"], sdr["Item_Desc"], Environment.NewLine));
                                _dpn.Add(sdr["DPN"].ToString() +" - " +sdr["Item_Desc"].ToString());
                            }
                        }
                        conn.Close();
                        context.Response.Write(new JavaScriptSerializer().Serialize(_dpn));
                    }
                }
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
    
    
    ***************************
     <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
            <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
            <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />      
             <script type="text/javascript">
                $(function () {
                    initializer();
                });
                var prmInstance = Sys.WebForms.PageRequestManager.getInstance();
                prmInstance.add_endRequest(function () {
                    //you need to re-bind your jquery events here
                    initializer();
                });
                function initializer() {
    
                    $("[id*=txtDPN]").autocomplete({ source: 
                       "/Handlers/SearchDPN.ashx" });
                }
            </script>
