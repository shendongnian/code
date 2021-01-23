    var depositoPorDocumento = ExistDT.AsEnumerable().ToDictionary(
        dr => dr.Field<Int64>("Documento"),
        dr => dr.Field<string>("Deposito")
    );
    foreach (var vr in VentasDT.AsEnumerable()) {
        Int64 id = Field<Int64>("Documento");
        string deposito;
        if (!depositoPorDocumento.TryGetValue(id, out deposito)) {
            continue;
        }
        dtResult.LoadDataRow(new object[]
         {
            id,
            vr.Field<DateTime>("Fecha"),
            vr.Field<string>("Articulo"),
            deposito,
            vr.Field<decimal>("ImpDMn"),
            vr.Field<decimal>("Cantidad"),
            vr.Field<string>("Partida"),
          }, false);
    }
    result.CopyToDataTable();
