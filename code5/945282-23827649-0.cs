    public ChildClassMap()
    {
       Table("Metody");
       Id(x => x.Id)
           .Column("Id")
           .UnsavedValue(-1);
       ...
