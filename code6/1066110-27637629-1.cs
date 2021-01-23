     public IEnumerable<PainelChamada> Search(PainelChamadaParamenters parameters)
     {
         var query = base.context.PaineisChamada.AsQueryable();
         if (parameters.Id.HasValue)
             query = query.Where(x => x.Id == parameters.Id);
         if (parameters.DataAcessoInicio.HasValue)
             query = query.Where(x => x.DataModificacao == parameters.DataAcessoInicio);
         if (parameters.DataAcessoFim.HasValue)
             query = query.Where(x => x.DataModificacao == parameters.DataAcessoFim);
         if (!string.IsNullOrEmpty(parameters.Descricao))
             query = query.Where(x => x.Descricao.Contains(parameters.Descricao));
         if (parameters.Fornecedores.Length > 0)
             query = query.Where(x => parameters.Fornecedores.ToList().Contains(x.Fornecedor));
         return query;
        }
  
