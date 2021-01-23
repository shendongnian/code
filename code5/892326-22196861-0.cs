    public override void Up(){
        var dirBase = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin",string.Empty) + @"\Migrations\SqlScripts";
        Sql(File.ReadAllText(dirBase + @"\CreateMyViews.sql"));
        Sql(File.ReadAllText(dirBase + @"\CreateMySproc.sql"));
    }
    
    public override void Down(){
            var dirBase = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin",string.Empty) + @"\Migrations\SqlScripts";
        Sql(File.ReadAllText(dirBase + @"\DropMySproc.sql"));
        Sql(File.ReadAllText(dirBase + @"\DropMyViews.sql"));
    }
