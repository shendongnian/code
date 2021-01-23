    public TableBMapping : ClassMap<TableB>
    {
        public TableBMapping()
        {
            // other struff
            Reference(x => x.TableA)Column("TableAId");
        }
    }
