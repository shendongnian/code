            var resultado = new ResultadoListagemPadrao();
            resultado.TotalRegistros = db.ASO.Total(usuarioLogado.EmpresaIDLogada);
            var query = (from a in db.ASO.ToListERP(usuarioLogado.EmpresaIDLogada).AsQueryable()
                    select new
                    {
                        a.ASOID,
                        a.FuncionarioID,
                        Cliente = a.Funcionario.Cliente.Pessoa.Nome,
                        Setor = a.FuncionarioFuncao.Funcao.Setor.Descricao,
                        Funcao = a.FuncionarioFuncao.Funcao.Descricao,
                        Funcionario = a.Funcionario.Pessoa.Nome,
                        a.DtASO,
                        a.Status                         
                    })
                .Where(where, filtro);
            resultado.TotalRegistrosVisualizados = query.Count();    
            resultado.Dados = query 
                .OrderBy(orderna + " " + ordenaTipo)
                .Skip(iniciarNoRegistro)
                .Take(qtdeRegistro)
                .ToArray();
    
            return resultado;
