      Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        NF.DataBase.Global.Conexao = new System.Data.EntityClient.EntityConnectionStringBuilder();
    // not provider
        NF.DataBase.Global.Conexao.ProviderConnectionString = "Data Source=source;Initial Catalog=base;User ID=user; Password=pass;";
