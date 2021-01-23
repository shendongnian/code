    var data = new List<EmployeeDto>();
    ...
    while (dr.Read())
    {
         data.Add(new EmployeeDto { 
                                    FirstName = dr.GetString(0),
                                    LastName = dr.GetString(1),
                                    Country = dr.GetString(2)
                                  });
    }
    ...
    Urunler.DataSource = data;
    Urunler.DataBind();
