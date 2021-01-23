        public List<view_ok> ListarPesquisa(string prof)
        {
            PesquisaBETAEntities pb = new PesquisaBETAEntities();
            var query = (from t0 in
                             (from v0 in pb.view_ok
                              group v0 by new
                              {
                                  v0.prof_nome,
                                  v0.resu1
                              }
                                  into gg
                                  select new
                                  {
                                      gg.Key.prof_nome,
                                      gg.Key.resu1
                                  })
                           where t0.prof_nome.Contains(prof)
                         select new { Professor = t0.prof_nome, P1 = t0.resu1 }).ToList();
            return query;
        }
