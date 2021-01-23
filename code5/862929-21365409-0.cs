    MyEntity e;
    e = DAL.GetRepository("MyEntity").Retrieve(x => x.Age > 20);
    validator = BAL.GetValidator<MyEntity>();
    if (validator.validate(e).HasErrors === false)
    {
        e.LastChecked = DateTime.Now;
        e.Broken = true;
        DAL.GetRepository("MyEntity").Update(e);
    } else {
        e.LastChecked = DateTime.Now;
        e.Broken = false;
        DAL.GetRepository("MyEntity").Update(e);
    }
