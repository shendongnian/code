            SchemaBuilder.CreateTable("TrackPartRecord", t => t
                .ContentPartRecord()
                );
            SchemaBuilder.CreateTable("TrackInformationRecord", t => t
                .Column<int>("Id", column => column.PrimaryKey().NotNull())
                .Column<int>("TrackPartRecord_Id")
                .Column<string>("Title", c => c.WithLength(50).NotNull())
                .Column<string>("Description", c => c.NotNull())
                .Column<bool>("IsDeleted")
               );
