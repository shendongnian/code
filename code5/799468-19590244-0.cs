    dal.excluirClientesRecurso(conexao, trx);
    // ...
    public void excluirClientesRecurso(SqlConnection conexao,
         SqlTransaction transaction = null)
    {
        executaComando("TRUNCATE TABLE dbo.RECURSO_CLIENTE",
            conexao, transaction);
    }
    public void executaComando(string query, SqlConnection conexao,
         SqlTransaction trasaction = null)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.Trasnaction = transaction;
            // ...
