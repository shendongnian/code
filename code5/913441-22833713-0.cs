    IEnumerable<MyDto> list = Model.Environments;
            
    return list.Where(item => !id.HasValue ? true :
                      item.IdCiaDespliegue == id.Value)
               .Where(item => string.IsNullOrWhiteSpace(name) ? true :
                      item.NombreCiaDespliegue == name)
               .Where(item => !id2.HasValue ? true :
                      item.IdContenidoEntorno == id2.Value)
               .Where(item => string.IsNullOrWhiteSpace(name2) ? true :
                      item.ContenidoEntorno == name2)
               .Where(item => string.IsNullOrWhiteSpace(entorno) ? true :
                      item.Entorno == entorno)
               .Where(item => !shouldBe.HasValue ? true :
                      item.DebeEtiquetar == shouldBe)
               .Where(item => string.IsNullOrWhiteSpace(mode) ? true :
                      item.Modo == mode)
               .ToList();
