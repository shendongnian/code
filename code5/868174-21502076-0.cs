    if (vm.ListAliases != null)
    {
        foreach (var item in vm.ListAliases )
        {
            var eAlias = new PlayerAliases() { CodPlayerAlias = item.CodPlayerAlias };
            db.PlayerAliases.Attach(eAlias);
            eAlias.Column1 = item.Column1;
            eAlias.Column2 = item.Column2;
        }
    }
