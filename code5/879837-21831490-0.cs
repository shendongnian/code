    var rows = clientes.Select(c => new
            {
                c.Id,
                c.Nome,
                Telefone = String.Format("(0{0}) {1}", c.DDD, c.Telefone),
                c.Email,
                Veiculo = (from v in c.Veiculos *where v.ClientId == c.Id* select new { v.Id, v.Modelo, v.Chassi }),
            })
        .Skip(pageNumber > 1 ? qtdRows * (pageNumber - 1) : 0)
        .Take(qtdRows)
        .ToArray();
