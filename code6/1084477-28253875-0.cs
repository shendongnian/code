    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        AddIfNotExists("Toscana", "Firenze");
        AddIfNotExists("Toscana", "Prato");
        var gruppi = ...
        ...
    }
    private void AddIfNotExists(string regione, string provincia)
    {
        if (!reg.Any(r => r.NomeProvincia == regione && r.NomeProvincia == provincia))
        {
            reg.Add(new Regioni { NomeRegione = regione, NomeProvincia = provincia });
        }
    }
