    var llamados = context.Set<Llamados>().AsQueryable();
    
    var query = llamados
    .Select(e => new ComplexLlamadosAfil { IdLlamado = e.IdLlamado });
    
    //If some conditions
    
    query = query.Where(e => diagnosticos.Any(d => d.IdLlamado == e.IdLlamado &&
                        d.Descripcion.Contains(diagnostico)) == true);
