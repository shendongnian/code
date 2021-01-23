    var res4 = dtEmp.AsEnumerable()
        .SelectMany(u => dtDept.AsEnumerable(), (u, v) => new {u, v})
        .Select(@t => new {@t, DOJ = u.Field<DateTime>("DOJ")})
        .Where(@t => u.Field<int>("DepartmentID") == v.Field<int>("DepartmentID") &&
                        DOJ > new DateTime(2014, 01, 04)).Select(@t => new
                        {
                            Name = u.Field<string>("Name"),
                            Department = v.Field<string>("DepartmentName")
                        });
