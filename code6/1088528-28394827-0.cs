    protected bool Initialized = false;
    protected  override void OnNavigatedTo(NavigationEventArgs e)
    {  
        if(!Initialized)
        {
            Initialized = true;
            reg.Add(
                new Regioni
                {
                    NomeRegione = "Toscana",
                    NomeProvincia = "Firenze"
                });
            reg.Add(
                new Regioni
                {
                    NomeRegione = "Toscana",
                    NomeProvincia = "Prato"
                });
        }
    }
