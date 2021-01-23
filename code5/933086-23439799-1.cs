      Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        NF.DataBase.Global.Conexao = new System.Data.EntityClient.EntityConnectionStringBuilder();
    // not provider
        NF.DataBase.Global.Conexao.ProviderConnectionString = "Data Source=clinicadotrabalho.tryb.biz,6015;Initial Catalog=SESMT;User ID=sa; Password=cicasia;";
