       var res = (from x in ctx.EmployeeAccess
	             join y in ctx.View_SystemAdminMembers on x.GroupId equals y.groupId
	             where x.EmpNo = '50'
	             select new
	             {
		             x.EmpNo,
		             y.LNameByFName,
		             y.GroupName,
		             y.Role,
		             y.Active,
		             Expr4 = y.EmpNo,
		             y.RoleID
	             });
