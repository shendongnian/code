    //Don't tell that it's a DbSet<Llamados>. You want an IQueryable<Llamados>
    IQueryable<Llamados> llamados = context.Set<Llamados>().AsQueryable();
    
    IQueryable<ComplexLlamadosAfil> query = llamados
    .Select(e => new ComplexLlamadosAfil { IdLlamado = e.IdLlamado });
    
    //If some conditions
    
    query = query.Where(e => diagnosticos.Any(d => d.IdLlamado == e.IdLlamado &&
                        d.Descripcion.Contains(diagnostico)) == true);
