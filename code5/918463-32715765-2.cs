    public MySagaMap()
		{
			SchemaAction(NHibernate.Mapping.ByCode.SchemaAction.None);
			Table("dbo.[tTable]");
			Property(x => x.Id);
			Property(x => x.CloseDate);
		}
	}
