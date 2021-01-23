    string sql = @"
    SELECT
        idcliente, Nome, Endere, tel_empresa, celular,
        UF, CEP, Email, Contato, Referencia, OBS, Nasc,
        cpf, cnpj, Iest
    FROM
        tbcliente
    ";
    SqlConnection conn = new SqlConnection("Your connection string");
    DataSet grava = new DataSet();
    SqlDataAdapter da2 = new SqlDataAdapter(sql, conn);
    SqlCommandBuilder constru6 = new SqlCommandBuilder(da2);
