    var results = (from ea in DbContext.EmployeeAccess
                   join sam in DbContext.View_SystemAdminMembers on ea.GroupId equals sam.GroupId
                   where ea.EmpNo = '50'
                   select new {
                     ea.EmpNo,
                     sam.LNameByFName,
                     sam.GroupName,
                     sam.Role,
                     sam.Active,
                     Expr4 = sam.EmpNo,
                     sam.RoleID
                   };
