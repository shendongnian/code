    Variable variableAlias = null;
    VariableLigera variableLigeraAlias = null;
    var result = _session
        .QueryOver(() => variableAlias).Where(x => x.Eliminado == false)
        .Select(
            Projections.Property(() => variableAlias.Id).WithAlias(() => variableLigeraAlias.Id),
            Projections.Property(() => variableAlias.Nombre).WithAlias(() => variableLigeraAlias.Nombre),
            Projections.Property(() => variableAlias.Descripcion).WithAlias(() => variableLigeraAlias.Descripcion),
            Projections.Property(() => variableAlias.Temporal).WithAlias(() => variableLigeraAlias.Temporal),
            Projections.Subquery(
                QueryOver.Of<ValorVariable>()
                    .Where(vv => vv.Variable.Id == variableAlias.Id)
                    .Select(vv => vv.Valor)
                    .Take(1)
            ).WithAlias(() => variableLigeraAlias.Valor)
        )
        .TransformUsing(Transformers.AliasToBean<VariableLigera>())
        .List<VariableLigera>();
