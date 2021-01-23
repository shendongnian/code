    public class Entity3Map : ClassMap<Entity3>
    {
        public Entity3Map()
        {
            Id(x => x.Id);
            HasManyToMany(x => x.Dict)
                .Table("linkTable")
                .Cascade.All()
                .AsEntityMap();
        }
    }
    var e1 = new Entity1();
    var e2 = new Entity2();
    using (var tx = session.BeginTransaction())
    {
        session.Save(e1);
        session.Save(new Entity3 { Dict = { { e1, e2 } } });
        tx.Commit();
    }
    session.Clear();
    var entity3 = session.Query<Entity3>().FetchMany(x => x.Dict).ToList().First();
    Assert.Equal(1, entity3.Dict.Count);
    Assert.Equal(e1.Id, entity3.Dict.First().Key.Id);
    Assert.Equal(e2.Id, entity3.Dict.First().Value.Id);
