    var res2 = dtEmp.AsEnumerable()
        .SelectMany(u => dtDept.AsEnumerable(), (u, v) => new {u, v})
        .Where(@t => u.Field<int>("DepartmentID") == v.Field<int>("DepartmentID") &&
                    u.Field<double>("Salary") > 10000).Select(@t => new
                    {
                        Name = u.Field<string>("Name"),
                        Department = v.Field<string>("DepartmentName")
                    });
