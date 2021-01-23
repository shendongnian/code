      Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        NF.DataBase.Global.Conexao = new System.Data.EntityClient.EntityConnectionStringBuilder();
        NF.DataBase.Global.Conexao.Provider = "System.Data.SqlClient";
        NF.DataBase.Global.Conexao.ProviderConnectionString = "Data Source=source;Initial Catalog=base;User ID=user; Password=pass;";
