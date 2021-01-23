    dtEmp.AsEnumerable()
        .Join(dtDept.AsEnumerable(),
            u => u.Field<int>("DepartmentID"),
            v => v.Field<int>("DepartmentID"),
            (u, v) => new { u, v })
        .GroupBy(τ0 => τ0.v.Field<string>("DeptName"), τ0 => τ0.u)
        .Select(g => new { DeptName = g.Key, Records = g })
