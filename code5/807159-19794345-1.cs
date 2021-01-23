    Please see my example.
    Web.config:
    <connectionStrings>
        <add name="DBC" connectionString="data source=.; database=DB; integrated     
    security=SSPI" providerName="System.Data.SqlClient"/>
    </connectionStrings>
    Try this in the Web Form:
    string CN = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    using (DbConnection cn = this.CreateConnection())
    {
        using (DbCommand cmd = this.CreateCommand(CN))
        {
            cmd.CommandText = "CADASTRAR";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(this.CreateParameter("@Nome", DbType.String, Nome));
            cmd.Parameters.Add(this.CreateParameter("@Sexo", DbType.String, Sexo));
            cmd.Parameters.Add(this.CreateParameter("@Data", DbType.String, Data));
            cmd.Parameters.Add(this.CreateParameter("@Email", DbType.String, Email));
        }
    }
