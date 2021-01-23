    var listaProdottiFiltrata = listaProdotti
        .Distinct()
        .GroupBy(g => new { g.ProdNome, g.ProdCodice })  // <-- added another value to group on
        .Select(group => new DettaglioRiga
        {                    
            ProdNome = group.Key.ProdNome,
            ProdCodice = group.Key.ProdCodice,   
            ProdQuantitaTotale = group.Sum(D => D.ProdQuantitaTotale), 
            ProdCostoSingolo = group.Sum(C => C.ProdCostoSingolo) 
        });
