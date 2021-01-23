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
