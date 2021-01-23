    IEnumerable<MyDto> list = Model.Environments;
                
    return list.Where(item => !id.HasValue                       || item.IdCiaDespliegue == id.Value)
               .Where(item => string.IsNullOrWhiteSpace(name)    || item.NombreCiaDespliegue == name)
               .Where(item => !id2.HasValue                      || item.IdContenidoEntorno == id2.Value)
               .Where(item => string.IsNullOrWhiteSpace(name2)   || item.ContenidoEntorno == name2)
               .Where(item => string.IsNullOrWhiteSpace(entorno) || item.Entorno == entorno)
               .Where(item => !shouldBe.HasValue                 || item.DebeEtiquetar == shouldBe)
               .Where(item => string.IsNullOrWhiteSpace(mode)    || item.Modo == mode)
               .ToList();
