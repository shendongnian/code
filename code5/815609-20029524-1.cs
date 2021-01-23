    public MyModel GetData()
    {
        MyModel model = new MyModel();
        model.Countries = DBContext.tblCountries.Where(c=>c.Id > 0).Take(10);
        model.RowCount = DBContext.tblCountries.Where(c=>c.Id > 0).Count();
        return model;
    }
