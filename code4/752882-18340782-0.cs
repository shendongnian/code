        // Creating table KeynoteInformationRecord
        SchemaBuilder.CreateTable("KeynoteInformationRecord", table => table
            .Column("Id", DbType.Int32, column => column.PrimaryKey().Identity())
            .Column("KeynotePartId", DbType.Int32)
            .Column("Title", DbType.String, column => column.Unlimited())
            .Column("Description", DbType.String, column => column.Unlimited())
            .Column("StartDate", DbType.DateTime)
            .Column("EndDate", DbType.DateTime)
            .Column("HasEvaluation", DbType.Boolean)
            .Column("IsDeleted", DbType.Boolean)
        );
