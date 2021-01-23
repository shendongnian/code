    public override void Up()
    {
        AddColumn("dbo.Results", "ResultsDataTmp", c => c.Binary());
        Sql(@"
        UPDATE dbo.Results
        SET ResultsDataTmp = CAST(ResultsData AS VARBINARY(MAX))
            END
        ");
        DropColumn("dbo.Results", "ResultsData");
        RenameColumn("dbo.Results", "ResultsDataTmp", "ResultsData");
    }
