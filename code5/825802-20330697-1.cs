    var groupedData = cta.get_TarifasAplicadas(id_Proforma)
        .GroupBy(n => new {n.no_Voucher, n.voucher, n.DWT, n.GRT, n.LOA, n.Fecha})
        .Select(g => new
                       {
                           g.Key.no_Voucher,
                           g.Key.voucher,
                           ITBIS = g.Sum(r => r.ITBIS),
                           MONTO = g.Sum(r => r.Monto),
                           g.Key.DWT,
                           g.Key.GRT,
                           g.Key.LOA,
                           g.Key.Fecha 
                       });
