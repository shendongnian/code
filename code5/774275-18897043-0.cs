    public TableAMapping : ClassMap<TableA>
    {
        public TableAMapping()
        {
            // other struff
            HasMany(x => x.TableB).Table("TableB").KeyColumn("TableAId");
        }
    }
