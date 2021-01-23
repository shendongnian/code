    var lookup = new Dictionary<int, Clt_cadCliente>();
    cn.Query<Clt_cadCliente, Clt_cadContatos, Clt_cadCliente>(@"
        SELECT s.*, a.IdCliente, a.OtherField1, a.OtherField2, etc ....
        FROM Clt_cadCliente s
        INNER JOIN Clt_cadContatos a ON s.IdCLiente = a.IdCliente  ", (s, a) =>
        {
            Clt_cadCliente shop;
            if (!lookup.TryGetValue(s.IdCliente, out shop))
            {
                lookup.Add(s.IdCliente, shop = s);
            }
            shop.Clt_cadContatos.Add(a);
            return shop;
        }, splitOn: "IdCliente").AsQueryable();
        var resultList = lookup.Values;
