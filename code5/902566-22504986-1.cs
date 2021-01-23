    List<Entidades> clientes = Admin.GetAllClientes(email);
    model.Clientes = new List<int>(); // Added this line to instantiate the property
    foreach (Entidades cliente in clientes)
    {
        model.Clientes.Add(cliente.IDEntidade);
    }
    List<TiposClientes> tipos = Admin.GetTiposClientes(email);
    model.TiposClientes = new List<int>(); // Added this line to instantiate the property
    foreach (TiposClientes tipo in tipos)
    {
        model.TiposClientes.Add(tipo.IDTipoCliente);
    }
