    var query =
	from ea in context.EmployeeAccess
	join vsam in context.View_SystemAdminMembers on ea.GroupID equals vsam.GroupID
	where ea.EmpNo == "01"
	select new
	{
		ea.EmpNo, vsam.LNameByFName, vsam.GroupName, vsam.Role, vsam.Active, vsam.EmpNo, vsam.RoleID
	};
