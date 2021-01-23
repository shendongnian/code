    MyEntity e;
    Repository<MyEntity> r;
    r = DAL.GetRepository<MyEntity>;
    e = r.Retrieve(x => x.Age > 20);
    v = BAL.GetValidator<MyEntity>();
    e.Broken = !v.Validate(e).HasErrors;
    e.LastChecked = DateTime.Now;
    DAL.GetRepository("MyEntity").Update(e);
