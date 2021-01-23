    if (StartYear < 2005)
       {
           string ConString = "Data Source=ORACLE;User ID=****;Password=****";
           string CodeUpdate = "update R70A109 set IDENTIFIER = :New_Identifier where StartYear = :StartYear) AND (EndYear = :EndYear) AND (IDENTIFIER = :Old_Identifier)";
           using (OracleConnection con = new OracleConnection(ConString))
           {
                OracleCommand SqlCodeUpdate = new OracleCommand(CodeUpdate, con);
                SqlCodeUpdate.Parameters.Add(new OracleParameter("@New_Identifier", IdentifierNew));
                SqlCodeUpdate.Parameters.Add(new OracleParameter("@StartYear", StartYear));
                SqlCodeUpdate.Parameters.Add(new OracleParameter("@EndYear", EndYear));
                SqlCodeUpdate.Parameters.Add(new OracleParameter("@Old_Identifier", IdentifierOld));
                SqlCodeUpdate.Connection.Open();
                SqlCodeUpdate.ExecuteNonQuery();
           }
    
        }
    ...
