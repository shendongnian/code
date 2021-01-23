       SqlParameter sqlParmInsLeitura1 = new SqlParameter("EmpCod", SqlDbType.VarChar);
       sqlParmInsLeitura1.Value = (object)empresaUsuario.Trim();
       SqlParameter sqlParmInsLeitura2 = new SqlParameter("EstTip", SqlDbType.BigInt);
       sqlParmInsLeitura2.Value = (object)tipoEstoqueUsuario;
       SqlParameter sqlParmInsLeitura3 = new SqlParameter("ProFamCod", SqlDbType.VarChar);
       sqlParmInsLeitura3.Value = (object)familia.Trim();
       SqlParameter sqlParmInsLeitura4 = new SqlParameter("ProFamCodLike", SqlDbType.VarChar);
       sqlParmInsLeitura4.Value = (object)familia.Trim() + ".%";
       SqlParameter sqlParmInsLeitura5 = new SqlParameter("FilCod", SqlDbType.VarChar);
       sqlParmInsLeitura5.Value = (object)filial.Trim();
    
       comando.Parameters.Add(sqlParmInsLeitura1);
       comando.Parameters.Add(sqlParmInsLeitura2);
       comando.Parameters.Add(sqlParmInsLeitura3);
       comando.Parameters.Add(sqlParmInsLeitura4);
       comando.Parameters.Add(sqlParmInsLeitura5);
