       Table("vCities");
       ...
       Id(x => x.Code)
          .Column("Code")
          .GeneratedBy.Assigned() // NHibernate expects that ID is managed by us
          .UnsavedValue("verydummyvalue or even null")
