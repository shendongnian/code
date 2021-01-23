    public void excluirClientesRecurso(SqlConnection conexao,
                                       SqlTransaction transaction)
    {
        executaComando("TRUNCATE TABLE dbo.RECURSO_CLIENTE", conexao);
    }
    
    public void executaComando(string query, SqlConnection conexao,
                               SqlTransaction transaction)
    {
        SqlCommand cmd = new SqlCommand(query);
        cmd.Connection = conexao;
        cmd.Transaction = transaction
        cmd.ExecuteNonQuery();
        conexao.Close();
    }
    // Usage
    dal.excluirClientesRecurso(conexao, trx);
