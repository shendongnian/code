    SELECT EmployeeAccess.EmpNo, View_SystemAdminMembers.LNameByFName, View_SystemAdminMembers.GroupName,
    		View_SystemAdminMembers.Role, View_SystemAdminMembers.Active, View_SystemAdminMembers.EmpNo, 
    		View_SystemAdminMembers.RoleID 
    FROM EmployeeAccess 
    	INNER JOIN View_SystemAdminMembers ON EmployeeAccess.GroupID = View_SystemAdminMembers.GroupID 
    WHERE (EmployeeAccess.EmpNo = '01')
