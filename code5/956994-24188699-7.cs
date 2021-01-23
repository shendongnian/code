    Table("COUNTRIES")
    Id(x => x.Id, "COUNTRY_ID").GeneratedBy.Identity();
    HasMany(x => x.Languages)
       .Cascade
       .SaveUpdate()
       .KeyColumn("COUNTRY_ID")
       .Inverse() // here we go
       ; 
