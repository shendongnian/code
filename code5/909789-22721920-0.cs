    var query =
        from Pedidos in context.Pedidos
        join Clientes in context.Clientes on Pedidos.ID_Cliente equals Clientes.ID_Cliente
        where Pedidos.ID_Comprobante == sComprobante      
        select new { Pedidos, Clientes };              
    if (MyCliente != null)
    {
        query = query.Where(i => i.Pedidos.ID_Cliente == MyCliente.ID_Cliente);
        query = query.Where(i => i.Periodos.ID_Cliente == MyCliente.ID_Cliente);
    }
    if (dDesde != null && dHasta != null)
        query = query.Where(i => i.Pedidos.Fecha >= dDesde && i.Pedidos.Fecha <= dHasta);
    if (bCumplidos == false)
        query = query.Where(i => i.Pedidos.Entregado == false);      
    return (from x in query
            let Pedidos = x.Pedidos
            let Clientes = x.Clientes
            select new PedidosList {ID_Pedido = Pedidos.ID_Pedido, Fecha=Pedidos.Fecha, Aprobado=Pedidos.Aprobado, Bruto=Pedidos.Bruto, Cliente=Clientes.RazonFantasia, FechaEntrega=Pedidos.FechaEntrega, Neto=Pedidos.Neto, Numero=Pedidos.Numero, Observaciones=Pedidos.Observaciones, Entregado=Pedidos.Entregado, ID_Cliente=Pedidos.ID_Cliente
            }).ToList(); 
