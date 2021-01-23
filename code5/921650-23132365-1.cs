    public class table1Map: ClassMap<table1>
    {
      public table1Map()
      {
        Table("table1");
        Id(x => x.Id);
        HasMany(x => x.table2s).Cascade.All();
      }
    }
    public class table2Map: ClassMap<table2>
    {
      public table2Map()
      {
        Table("table2");
        Id(x => x.Id);
        References(x => x.instance);
      }
    }
