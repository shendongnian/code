    <#@ template   language    = "C#"                           #>
    <#@ assembly   name        = "Microsoft.CSharp"             #>
    <#@ assembly   name        = "System.Core"                  #>
    <#@ assembly   name        = "System.Data"                  #>
    <#@ import     namespace   = "System.Collections.Generic"   #>
    <#@ import     namespace   = "System.Dynamic"               #>
    <#@ import     namespace   = "System.Linq"                  #>
    <#@ import     namespace   = "System.Data.SqlClient"        #>
    public class ActionTypes 
    {
    <#
    var con = new SqlConnection("Data Source=localhost\SQLExpress;Initial Catalog=MyDatabaseName;Integrated Security=True");
    con.Open();
    var sqc = new SqlCommand("SELECT ActionTypeID, ActionTypeName FROM ActionTypes", con);
    var reader = sqc.ExecuteReader();
    using (var reader = sqc.ExecuteReader())
    {
        while (reader.Read())
        {
    #>
        public static Guid <#=reader.GetString(reader.GetOrdinal("ActionTypeName"))#> = new Guid("<#=reader.GetGuid(reader.GetOrdinal("ActionTypeID"))#>");
    <#
        }
    }
    con.Close();
    #>
    }
