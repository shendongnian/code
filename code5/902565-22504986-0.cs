    List<Entidades> clientes = Admin.GetAllClientes(email);
    foreach (Entidades cliente in clientes)
    {
        model.Clientes.Add(cliente.IDEntidade);
    }
    List<TiposClientes> tipos = Admin.GetTiposClientes(email);
    foreach (TiposClientes tipo in tipos)
    {
        model.TiposClientes.Add(tipo.IDTipoCliente);
    }
