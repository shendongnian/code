    Variable variableAlias = null;
    VariableLigera variableLigeraAlias = null;
    ValorVariable valorVariableAlias = null;
    var result = _session
            .QueryOver(() => variableAlias).Where(x => x.Eliminado == false)
            .JoinAlias(() => variableAlias.Valores, () => valorVariableAlias)
            .SelectList(projections => projections
                .Select(() => variableAlias.Id).WithAlias(() => variableLigeraAlias.Id),
                .Select(() => variableAlias.Nombre).WithAlias(() => variableLigeraAlias.Nombre),
                .Select(() => variableAlias.Descripcion).WithAlias(() => variableLigeraAlias.Descripcion),
                .Select(() => variableAlias.Temporal).WithAlias(() => variableLigeraAlias.Temporal),
                .SelectSubQuery(QueryOver.Of<ValorVariable>( () => valorVariableAlias)
									.Where(vv => vv.IdVariable == variableAlias.Id)
                .Select(Projections.Max<ValorVariable>(vv => vv.FechaValor)))
									.Select(Projections.Property(() => valorVariableAlias.Valor))
               .WithAlias(() => variableLigeraAlias.Valor)
            )
            .TransformUsing(Transformers.AliasToBean<VariableLigera>())
            .List<VariableLigera>();
